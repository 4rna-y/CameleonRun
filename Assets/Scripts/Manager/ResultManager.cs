using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ResultAnimationComponent))]
[RequireComponent(typeof(ResultInputComponent))]
[RequireComponent(typeof(ResultSetterComponent))]
public class ResultManager : MonoBehaviour
{
    private ResultAnimationComponent _animation;
    private ResultInputComponent _input;
    private ResultSetterComponent _setter;

    void Start()
    {
        _animation = this.GetComponent<ResultAnimationComponent>();
        _input = this.GetComponent<ResultInputComponent>();
        _setter = this.GetComponent<ResultSetterComponent>();

        _animation.Initialize();
        _setter.Initialize();    
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.IsKeyDownSpace())
        {
            SceneManager.LoadScene("RankScene");
        }
    }
}
