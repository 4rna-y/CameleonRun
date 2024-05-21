using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GoalFlagFeatureComponent))]
[RequireComponent(typeof(GoalFlagAnimationComponent))]
public class GoalFlagComponent : MonoBehaviour
{
    private GoalFlagFeatureComponent _feature;
    private GoalFlagAnimationComponent _animation;

    // Start is called before the first frame update
    void Start()
    {
        _feature = this.GetComponent<GoalFlagFeatureComponent>();
        _animation = this.GetComponent<GoalFlagAnimationComponent>();
        _animation.BeginAnimation();
    }

    void Update()
    {
        if (_feature.CheckCollided())
        {
            _animation.PauseAll();
        }
    }
}
