using UnityEngine;
using UnityEngine.UI;

public class IngameHighscore : MonoBehaviour
{
    [SerializeField]
    private Text[] highscoreTexts;

    private void Start()
    {
        SetHighscores();
    }

    private void SetHighscores()
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            Text currentHighscoreText = highscoreTexts[i];
            int highScoreIndex = i + 1;
            currentHighscoreText.text = highScoreIndex + ". " + PlayerPrefs.GetInt("Highscore" + highScoreIndex);
        }
    }
}