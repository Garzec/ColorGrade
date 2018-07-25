using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class IngameScore : MonoBehaviour
{
    [SerializeField]
    private Text txt;

    private int currentHighscore = 0;

    private void Start()
    {
        UpdateHighscoreText();
    }

    public void ChangeHighscore(int currentValue)
    {
        currentHighscore = currentValue;
        UpdateHighscoreText();
    }

    private void UpdateHighscoreText()
    {
        txt.text = currentHighscore.ToString();
    }

    public void SaveScore()
    {
        List<int> scores = new List<int>();
        scores.Add(PlayerPrefs.GetInt("Highscore1"));
        scores.Add(PlayerPrefs.GetInt("Highscore2"));
        scores.Add(PlayerPrefs.GetInt("Highscore3"));
        scores.Add(PlayerPrefs.GetInt("Highscore4"));
        scores.Add(PlayerPrefs.GetInt("Highscore5"));
        scores.Add(currentHighscore);

        scores = scores.OrderByDescending(x => x).ToList();

        PlayerPrefs.SetInt("Highscore1", scores[0]);
        PlayerPrefs.SetInt("Highscore2", scores[1]);
        PlayerPrefs.SetInt("Highscore3", scores[2]);
        PlayerPrefs.SetInt("Highscore4", scores[3]);
        PlayerPrefs.SetInt("Highscore5", scores[4]);
    }
}