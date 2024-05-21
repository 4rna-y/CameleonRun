using Chameleon.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayModeManager : MonoBehaviour
{
    public static PlayModeManager Instance;

    [SerializeField] public TextMeshProUGUI ClockTimerText;
    [SerializeField] public TextMeshProUGUI CoinText;
    [SerializeField] public TextMeshProUGUI DeathText;

    [SerializeField] public PlayerComponent PlayerComponent;

    [SerializeField] public GameModes GameMode;

    void Start()
    {
        Instance = this;
        PlayerComponent.Initialize();
    }

    void Update()
    {
        PlayerComponent.OnUpdate();
        UpdateUI();
    }

    public void OnFinish()
    {
        Time.timeScale = 1.0f;
        Game.Instance.SessionModule.CreateSession(
            GameMode, 
            PlayerComponent.LifeTime, 
            PlayerComponent.DeathCount, 
            PlayerComponent.CoinCount);

        SceneManager.LoadScene("ResultScene");
    }

    private void UpdateUI()
    {
        ClockTimerText.text = PlayerComponent.LifeTime.ToString("F");
        CoinText.text = PlayerComponent.CoinCount.ToString();
        DeathText.text = PlayerComponent.DeathCount.ToString();
    } 
}
