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
        colors.Add(-4, new Color32(255, 51, 51, 255)); // rot
        colors.Add(-3, new Color32(51, 173, 255, 255)); // blau
        colors.Add(-2, new Color32(77, 255, 77, 255)); // grün
        colors.Add(-1, new Color32(255, 255, 77, 255)); // gelb
        colors.Add(10, new Color32(0, 0, 0, 255)); // schwarz
        colors.Add(20, new Color32(184, 46, 138, 255)); // violett
        colors.Add(30, new Color32(255, 153, 51, 255)); // orange
        colors.Add(40, new Color32(0, 255, 255, 255)); // türkis
        colors.Add(50, new Color32(0, 179, 0, 255)); // dunkelgrün
        colors.Add(60, new Color32(255, 255, 255, 255)); // weiß
        colors.Add(70, new Color32(51, 102, 153, 255)); // dunkelblau

        StartNextLevel();
    }

    private void StartNextLevel()
    {
        currentLevel++;
        Color[] rouletteColors = GetRouletteColors(currentLevel);
        Color ballColor = GetBallColor(rouletteColors);
        currentBallColor = ballColor;
        ball.Reset(ballColor);
        score.ChangeHighscore(currentLevel);
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