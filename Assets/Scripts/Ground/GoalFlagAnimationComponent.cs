using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlagAnimationComponent : MonoBehaviour
{
    [SerializeField] GameObject ModelUpper;
    [SerializeField] GameObject ModelLower;

    private Tween _upperPosTween;
    private Tween _upperRotTween;
    private Tween _lowerTween;

    public void BeginAnimation()
    {
        _upperPosTween = ModelUpper.transform
                .DOLocalMoveY(0.55f, 0.5f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(
                    () =>
                    {
                        Sequence seq = DOTween.Sequence();
                        seq.Append(
                            ModelUpper.transform
                                .DOLocalMoveY(0.25f, 0.5f)
                                .SetEase(Ease.InOutCubic)
                                .SetLoops(-1, LoopType.Yoyo));
                        _upperPosTween = seq;
                    });
        _upperRotTween = ModelUpper.transform
                .DORotate(new Vector3(0, 360f, 360f), 3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        _lowerTween = ModelLower.transform
                .DORotate(new Vector3(-360f, -360f, -360f), 3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
    }

    public void PauseAll()
    {
        _upperPosTween.Pause();
        _upperRotTween.Pause();
        _lowerTween.Pause();
    }
}
