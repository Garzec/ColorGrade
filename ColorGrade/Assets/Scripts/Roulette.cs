using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private Observer observer;

    private bool isRotating;

    private float initialRotationSpeed = 10;
    private float currentRotationSpeed;

    private List<RouletteColor> currentColors = new List<RouletteColor>();

    private void Start()
    {
        currentRotationSpeed = initialRotationSpeed;
    }

    private void Update()
    {
        TryRotate();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == ball)
        {
            observer.RouletteCollision(GetCurrentColor());
        }
    }

    public void StartRotating(int currentLevel, Color[] colors)
    {
        int lastDigit = currentLevel % 10;

        if (lastDigit == 0)
        {
            currentRotationSpeed = initialRotationSpeed;
        }
        else
        {
            currentRotationSpeed += lastDigit;
        }

        SetColors(colors);
        isRotating = true;
    }

    public void StopRotating()
    {
        isRotating = false;
    }

    private void TryRotate()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);
        }
    }

    private void SetColors(Color[] colors)
    {
        currentColors.Clear();

        for (int i = 0; i < colors.Length; i++)
        {
            Color newColor = colors[i];
            RouletteColor newRouletteColor = new RouletteColor(i, newColor, colors.Length);
            currentColors.Add(newRouletteColor);
        }

        Debug.LogError("noch nicht implementiert");
    }

    private Color GetCurrentColor()
    {
        Debug.LogError("noch nicht implementiert");

        // currentColors

        return Color.red;
    }
}