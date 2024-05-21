using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    [SerializeField] public GameObject GameModeImage;
    [SerializeField] public GameObject GameModeText;
    [SerializeField] public GameObject ScoreText;
    [SerializeField] public GameObject RankText;

    [SerializeField] public TextMeshProUGUI[] RankScoreTexts;

    [SerializeField] public Sprite[] GameModeImages;
    private string[] _gameModeTexts = new[] { "Easy", "Normal", "Hard" };
    // Start is called before the first frame update
    void Start()
    {
        GameModes mode = Game.Instance.SessionModule.GetCurrentSessionGameMode();
        int modeNum = (int)mode;
        GameModeImage.GetComponent<Image>().sprite = GameModeImages[modeNum];
        GameModeText.GetComponent<TextMeshProUGUI>().text = _gameModeTexts[modeNum];

        int score = GetScore();

        ScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();

        int rank = Game.Instance.RankModule.Add(new RankHistory(mode, score));
        RankText.GetComponent<TextMeshProUGUI>().text = rank.ToString();

        int i = 0;
        foreach (RankHistory his in Game.Instance.RankModule.GetHistories(mode))
        {
            RankScoreTexts[i].text = his.Score.ToString();
            i++;
        }
        for (int j = i; j < i + (3 - i); i++)
        {
            RankScoreTexts[j].text = "------";
        }
    }

    private int GetScore()
    {
        int scoreBase = 10000;
        float time = Game.Instance.SessionModule.GetCurrentSessionTime();
        int death = Game.Instance.SessionModule.GetCurrentSessionDeath();
        int point = Game.Instance.SessionModule.GetCurrentSessionPoint();
        scoreBase += point * 1000;
        scoreBase -= death * 500;
        scoreBase -= (int)(time - 10) * 100;
        return scoreBase;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
