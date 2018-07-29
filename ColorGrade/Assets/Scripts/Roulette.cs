using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private Observer observer;

    [SerializeField]
    private SpriteRenderer rend;

    private bool isRotating;

    private float initialRotationSpeed = 50;
    private float currentRotationSpeed;

    private List<Color> currentColors = new List<Color>();

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

        if (lastDigit == 0 && currentLevel < 80)
        {
            currentRotationSpeed = initialRotationSpeed;
        }
        else
        {
            currentRotationSpeed += lastDigit * 3;
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
        currentColors = colors.ToList();

        Texture2D circleTexture = GenerateCircleTexture(200); // 96
        Sprite circleSprite = Sprite.Create(circleTexture, new Rect(0, 0, circleTexture.width, circleTexture.height), new Vector2(0.5f, 0.5f), 1028);
        rend.sprite = circleSprite;
    }

    private Color GetCurrentColor()
    {
        float currentRotation = transform.eulerAngles.z % 360;
        float angleStep = 360 / currentColors.Count;
        int colorIndex = (int)(currentRotation / angleStep);
        return currentColors[colorIndex];
    }

    private Texture2D GenerateCircleTexture(int size)
    {
        Color[] pixels = new Color[size * size];
        Vector2 center = new Vector2(size / 2, size / 2);
        float anglePerColor = 360 / currentColors.Count;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Vector2 dir = new Vector2(x + 0.5f, y + 0.5f) - center;
                float angle = -Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
                angle = angle < 0 ? 360 + angle : angle;
                int colorIndex = Mathf.Min((int)(angle / anglePerColor), currentColors.Count - 1);
                pixels[x + y * size] = dir.magnitude < size * 0.5f ? currentColors[colorIndex] : Color.clear;
            }
        }

        Texture2D tex = new Texture2D(size, size);
        tex.SetPixels(pixels);
        tex.Apply();
        return tex;
    }
}