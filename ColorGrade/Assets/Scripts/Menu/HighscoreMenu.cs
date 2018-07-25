using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreMenu : Menu
{
    [SerializeField]
    private Text[] highscoreTexts;

    private void Start()
    {
        SetHighscores();
    }

    private void SetHighscores()
    {
        int[] highscores = GetHighscores();

        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            Text currentHighscoreText = highscoreTexts[i];
            int currentHighscoreValue = highscores[i];
            currentHighscoreText.text = currentHighscoreValue.ToString();
        }
    }

    private int[] GetHighscores()
    {
        List<int> scores = new List<int>();
        scores.Add(PlayerPrefs.GetInt("Highscore1"));
        scores.Add(PlayerPrefs.GetInt("Highscore2"));
        scores.Add(PlayerPrefs.GetInt("Highscore3"));
        scores.Add(PlayerPrefs.GetInt("Highscore4"));
        scores.Add(PlayerPrefs.GetInt("Highscore5"));

        return scores.ToArray();
    }
}