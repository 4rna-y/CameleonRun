using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAnimationComponent : MonoBehaviour
{
    [SerializeField] public GameObject TimeLabel;
    [SerializeField] public GameObject TimeImage;
    [SerializeField] public GameObject TimeText;

    [SerializeField] public GameObject CoinLabel;
    [SerializeField] public GameObject CoinImage;
    [SerializeField] public GameObject CoinText;

    [SerializeField] public GameObject DeathLabel;
    [SerializeField] public GameObject DeathImage;
    [SerializeField] public GameObject DeathText;

    public void Initialize()
    {   
        TimeLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, 620);
        TimeImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-135, 620);
        TimeText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 620);
        CoinLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-575, 620);
        CoinImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-575, 620);
        CoinText.GetComponent<RectTransform>().anchoredPosition = new Vector2(-575, 620);
        DeathLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(575, 620);
        DeathImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(575, 620);
        DeathText.GetComponent<RectTransform>().anchoredPosition = new Vector2(575, 620);

        DOVirtual.DelayedCall(0.5f, () => AnimateAppearing());
    }

    private void AnimateAppearing()
    {
        TimeLabel.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(50, 165), 0.5f).SetEase(Ease.InOutBack);
;
        TimeImage.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(-135, 165), 0.5f).SetEase(Ease.InOutBack);
        TimeText.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.InOutBack);
        ;
        CoinLabel.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(-575, -30), 0.5f).SetEase(Ease.InOutBack);
        ;
        CoinImage.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(-575, 125), 0.5f).SetEase(Ease.InOutBack);
        ;
        CoinText.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(-575, -175), 0.5f).SetEase(Ease.InOutBack);
        ;
        DeathLabel.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(575, -30), 0.5f).SetEase(Ease.InOutBack);
        ; 
        DeathImage.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(575, 125), 0.5f).SetEase(Ease.InOutBack);
        ;
        DeathText.GetComponent<RectTransform>()
            .DOAnchorPos(new Vector2(575, -175), 0.5f).SetEase(Ease.InOutBack);
        ;
    }

    private void AnimateDisappearing()
    {
        

    }
}
