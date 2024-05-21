using Chameleon.Player;
using Chameleon.Player.Automation.Interfaces;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public PlayerComponent Player;
    public RectTransform _keyImage;
    public Image Curtain;

    private int _downAkey;
    private bool _downADone;

    // Start is called before the first frame update
    void Start()
    {
        Player.Initialize();

        IAutomationTimeline timeline = new AutomationTimeline();
        Player.AutomationTimeline = timeline;
        Player.IsAuto = true;
        Player.IsTitle = true;

        Sequence seq = DOTween.Sequence();
        seq.SetLoops(-1, LoopType.Yoyo);
        seq.Append(_keyImage.DOScale(0.85f, 0.3f).SetEase(Ease.InOutCubic));
        seq.PrependInterval(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            AnimateFadeOut();
        }
        if (Input.GetKeyDown(KeyCode.A) && !_downADone)
        {
            if (_downAkey == 3)
            {
                _downADone = true;
            }
            _downAkey++;
        }
        if (Input.GetKeyDown(KeyCode.F1) && _downADone)
        {
            SceneManager.LoadScene("FPSScene");
        }
        Player.OnUpdate();
    }

    private void AnimateFadeOut()
    {
        DOTween.To(
            () => Curtain.color,
            col => Curtain.color = col,
            new Color(1, 1, 1, 1),
            0.75f)
            .OnComplete(() =>
            {
                SceneManager.LoadScene("ModeSelectScene");
            });
    }
}
