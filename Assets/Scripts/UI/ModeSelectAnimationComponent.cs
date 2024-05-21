using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ModeSelectorAnimationComponent : MonoBehaviour
{
    public RectTransform EasyCardAxis;
    public RectTransform NormalCardAxis;
    public RectTransform HardCardAxis;
    public RectTransform KeyInfos;

    public GameObject EasyCard;
    public GameObject NormalCard;
    public GameObject HardCard;

    public Volume CamEffects;

    public TextMeshProUGUI ProgressText;

    public bool IsInitialized { get; set; }

    private Vector3 _initPos = new Vector3(0, -260, 0);
    private Quaternion _initAngle = Quaternion.Euler(0, 0, 100);

    private DepthOfField _blur;

    public void Initialize()
    {
        CamEffects.profile.TryGet(out _blur);

        EasyCardAxis.anchoredPosition = _initPos;
        NormalCardAxis.anchoredPosition = _initPos;
        HardCardAxis.anchoredPosition = _initPos;
        EasyCardAxis.rotation = _initAngle;
        NormalCardAxis.rotation = _initAngle;
        HardCardAxis.rotation = _initAngle;
        KeyInfos.anchoredPosition = new Vector2(510, -600);
    }

    public void AnimateEnter()
    {
        DOVirtual.DelayedCall(0.5f, () =>
        {
            if (!IsInitialized)
            {
                EasyCardAxis
                    .DORotate(new Vector3(), 0.5f)
                    .SetEase(Ease.InOutCubic);
                NormalCardAxis
                    .DORotate(new Vector3(), 0.5f)
                    .SetEase(Ease.InOutCubic)
                    .SetDelay(0.2f);
                HardCardAxis
                    .DORotate(new Vector3(), 0.5f)
                    .SetEase(Ease.InOutCubic)
                    .SetDelay(0.4f)
                    .OnComplete(() =>
                    {
                        NormalCardAxis
                            .DORotate(new Vector3(0, 0, -5f), 0.5f)
                            .SetEase(Ease.InOutCubic);
                        HardCardAxis
                            .DORotate(new Vector3(0, 0, -10f), 0.5f)
                            .SetEase(Ease.InOutCubic);
                        KeyInfos
                            .DOAnchorPos(new Vector2(510, -460), 0.5f)
                            .SetEase(Ease.InOutCubic);
                        IsInitialized = true;
                    });

                EasyCardAxis
                    .DOAnchorPos(new Vector3(), 0.5f)
                    .SetEase(Ease.InOutCubic);
                NormalCardAxis.GetComponent<RectTransform>()
                    .DOAnchorPos(new Vector3(), 0.5f)
                    .SetEase(Ease.InOutCubic);
                HardCardAxis.GetComponent<RectTransform>()
                    .DOAnchorPos(new Vector3(), 0.5f)
                    .SetEase(Ease.InOutCubic);
            }
        });
    }

    public void AnimateLoad()
    {
        KeyInfos
            .DOAnchorPos(new Vector2(510, -600), 0.125f)
            .SetEase(Ease.InOutBack);
        ProgressText.DOFade(1, 0.25f);
        //_blur.active = true;
    }

    public void UpdateLoadingProgress(int progress)
    {
        ProgressText.text = $"{progress}%";
    } 

    public void SwapCard(int v)
    {
        if (v == 0)
        {
            EasyCardAxis
                .DORotate(new Vector3(0, 0, 100), 0.5f)
                .SetEase(Ease.InOutCubic);
            NormalCardAxis
                .DORotate(new Vector3(0, 0, 0f), 0.5f)
                .SetEase(Ease.InOutCubic);
            HardCardAxis
                .DORotate(new Vector3(0, 0, -5f), 0.5f)
                .SetEase(Ease.InOutCubic);
            EasyCardAxis
               .DOAnchorPos(new Vector3(0, -260, 0), 0.5f)
               .SetEase(Ease.InOutCubic);
        }
        else
        if (v == 1)
        {
            NormalCardAxis
                .DORotate(new Vector3(0, 0, 100f), 0.5f)
                .SetEase(Ease.InOutCubic);
            HardCardAxis
                .DORotate(new Vector3(0, 0, 0f), 0.5f)
                .SetEase(Ease.InOutCubic);
            NormalCardAxis
               .DOAnchorPos(new Vector3(0, -260, 0), 0.5f)
               .SetEase(Ease.InOutCubic);
        }
        else
        {
            EasyCardAxis
                .DORotate(new Vector3(0, 0, 0), 0.5f)
                .SetEase(Ease.InOutCubic)
                .SetDelay(0.1f);
            NormalCardAxis
                .DORotate(new Vector3(0, 0, -5f), 0.5f)
                .SetEase(Ease.InOutCubic);
            HardCardAxis
                .DORotate(new Vector3(0, 0, -10f), 0.5f)
                .SetEase(Ease.InOutCubic);
            EasyCardAxis
               .DOAnchorPos(new Vector3(0, 0, 0), 0.5f)
               .SetEase(Ease.InOutCubic);
            NormalCardAxis
               .DOAnchorPos(new Vector3(0, 0, 0), 0.5f)
               .SetEase(Ease.InOutCubic);
        }
    }
}
