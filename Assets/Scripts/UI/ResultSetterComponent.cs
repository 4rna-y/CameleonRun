using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultSetterComponent : MonoBehaviour
{
    [SerializeField] public GameObject GameModeImage;
    [SerializeField] public GameObject GameModeText;
    [SerializeField] public GameObject TimeText;
    [SerializeField] public GameObject DeathText;
    [SerializeField] public GameObject CoinText;

    [SerializeField] public Sprite[] GameModeImages;
    private string[] _gameModeTexts = new[] { "Easy", "Normal", "Hard" };

    public void Initialize()
    {


        TimeText.GetComponent<TextMeshProUGUI>().text 
            = Game.Instance.SessionModule.GetCurrentSessionTime().ToString("F");
        DeathText.GetComponent<TextMeshProUGUI>().text
            = Game.Instance.SessionModule.GetCurrentSessionDeath().ToString();
        CoinText.GetComponent<TextMeshProUGUI>().text
            = Game.Instance.SessionModule.GetCurrentSessionPoint().ToString();
    }
}
