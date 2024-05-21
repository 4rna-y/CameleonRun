using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinFeatureComponent))]
public class CoinComponent : MonoBehaviour
{
    private CoinFeatureComponent _feature;
    // Start is called before the first frame update
    void Start()
    {
        _feature = this.GetComponent<CoinFeatureComponent>();

        this.transform.DORotate(new Vector3(360, 0, 360), 3f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }

    void Update()
    {
        if (_feature.OnUpdate()) AnimateFadeOut();
    }

    private void AnimateFadeOut()
    {
        this.GetComponent<Renderer>().material.DOFade(0, 0.15f).OnComplete(() => this.enabled = false);
    }
}
