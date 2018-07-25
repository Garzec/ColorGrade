﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Roulette roulette;

    [SerializeField]
    private Ball ball;

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

        StartLevel();
    }

    private void StartLevel()
    {
        currentLevel++;
        Color[] rouletteColors = GetRouletteColors(currentLevel);
        Color ballColor = GetBallColor(rouletteColors);
        currentBallColor = ballColor;
        ball.ResetBall(ballColor);
        roulette.StartRotating(currentLevel, rouletteColors);
    }

    private void FinishLevel()
    {
        roulette.StopRotating();
    }

    public void RouletteCollision(Color currentRouletteColor)
    {
        if (currentRouletteColor == currentBallColor)
        {
            // weiter

            Debug.LogError("noch nicht implementiert");
        }
        else
        {
            // verloren

            Debug.LogError("noch nicht implementiert");
        }
    }

    private Color[] GetRouletteColors(int currentLevel)
    {
        Debug.LogError("Abfrage mal testen");

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