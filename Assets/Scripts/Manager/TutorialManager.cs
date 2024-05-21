using Chameleon.Player;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [SerializeField] public PlayerComponent PlayerComponent;
    [SerializeField] public TextMeshProUGUI ClockTimerText;
    [SerializeField] public TextMeshProUGUI CoinText;
    [SerializeField] public TextMeshProUGUI DeathText;

    private bool _isJumpAndSwap;
    private bool _isJumpAndSwapKey;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        PlayerComponent.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerComponent.OnUpdate();
        UpdateUI();

        if (PlayerComponent.transform.position.x >= 103f && !_isJumpAndSwap)
        {
            Time.timeScale = 0.01f;
            DOTween.timeScale = 0.01f;
            _isJumpAndSwap = true;
        }
    }

    private void UpdateUI()
    {
        ClockTimerText.text = PlayerComponent.LifeTime.ToString("F");
        CoinText.text = PlayerComponent.CoinCount.ToString();
        DeathText.text = PlayerComponent.DeathCount.ToString();
    }

    public void OnFinish()
    {

    }
}
