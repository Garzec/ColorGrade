using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Roulette roulette;

    [SerializeField]
    private Ball ball;

    [SerializeField]
    private GameObject btnDrop;

    [SerializeField]
    private IngameScore score;

    private int currentLevel = 0;
    private Color currentBallColor;

    private Dictionary<int, Color> colors = new Dictionary<int, Color>();

    private void Start()
    {
        colors.Add(-4, new Color(255, 51, 51)); // rot
        colors.Add(-3, new Color(51, 173, 255)); // blau
        colors.Add(-2, new Color(77, 255, 77)); // grün
        colors.Add(-1, new Color(255, 255, 77)); // gelb
        colors.Add(10, new Color(0, 0, 0)); // schwarz
        colors.Add(20, new Color(184, 46, 138)); // violett
        colors.Add(30, new Color(255, 153, 51)); // orange
        colors.Add(40, new Color(0, 255, 255)); // türkis
        colors.Add(50, new Color(0, 179, 0)); // dunkelgrün
        colors.Add(60, new Color(255, 255, 255)); // weiß
        colors.Add(70, new Color(51, 102, 153)); // dunkelblau

        StartNextLevel();
    }

    private void StartNextLevel()
    {
        currentLevel++;
        Color[] rouletteColors = GetRouletteColors(currentLevel);
        Color ballColor = GetBallColor(rouletteColors);
        currentBallColor = ballColor;
        ball.Reset(ballColor);
        roulette.StartRotating(currentLevel, rouletteColors);
        btnDrop.SetActive(true);
    }

    public void EnableBallDrop()
    {
        btnDrop.SetActive(false);
        roulette.StopRotating();
        ball.Drop();
    }

    public void RouletteCollision(Color currentRouletteColor)
    {
        if (currentRouletteColor == currentBallColor)
        {
            score.ChangeHighscore(currentLevel);
            StartNextLevel();
        }
        else
        {
            score.SaveScore();
            SceneManager.LoadScene("Highscore");
        }
    }

    private Color[] GetRouletteColors(int currentLevel)
    {
        return colors
            .Where(x => x.Key <= currentLevel)
            .Select(x => x.Value)
            .ToArray();
    }

    private Color GetBallColor(Color[] rouletteColors)
    {
        int colorIndex = Random.Range(0, rouletteColors.Length);
        return rouletteColors[colorIndex];
    }
}