using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ModeSelectorAnimationComponent))]
[RequireComponent(typeof(ModeSelectorInputComponent))]
public class ModeSelectManager : MonoBehaviour
{
    private ModeSelectorAnimationComponent _animationComponent;
    private ModeSelectorInputComponent _inputComponent;

    private int _selectedIndex;
    private bool _selected;
    private AsyncOperation _loader;

    void Start()
    {
        _animationComponent = this.GetComponent<ModeSelectorAnimationComponent>();
        _inputComponent = this.GetComponent<ModeSelectorInputComponent>();

        _animationComponent.Initialize();
        _animationComponent.AnimateEnter();
    }

    void Update()
    {
        if (_selected) return;
        if (_inputComponent.IsDownShift())
        {
            _animationComponent.SwapCard(_selectedIndex++);
            if (_selectedIndex == 3) _selectedIndex = 0;
        }

        if (_inputComponent.IsDownSpace())
        {
            _selected = true;
            if (_selectedIndex == 0)
            {
                LoadScene("EasyModeScene");
            }
            if (_selectedIndex == 1)
            {
                LoadScene("NormalModeScene");
            }
            if (_selectedIndex == 2)
            {
                LoadScene("HardModeScene");
            }
        }
        
    }

    private void LoadScene(string name)
    {
        _animationComponent.AnimateLoad();
        StartCoroutine(CoLoad(name));
    }

    private IEnumerator CoLoad(string name)
    {
        _loader = SceneManager.LoadSceneAsync(name);
        _loader.allowSceneActivation = false;
        while (!_loader.isDone)
        {
            _animationComponent.UpdateLoadingProgress((int)(_loader.progress * 100));
            if (_loader.progress >= 0.9f)
            {
                _loader.allowSceneActivation = true;
            }
            yield return null;
        }
        _loader.allowSceneActivation = true;
        yield return null;
    }
}
