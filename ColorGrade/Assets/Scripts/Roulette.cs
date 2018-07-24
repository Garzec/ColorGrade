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
        if (currentLevel % 10 == 0)
        {
            currentRotationSpeed = initialRotationSpeed;
        }
        else
        {
            currentRotationSpeed += currentLevel;
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
        // ...
    }

    private Color GetCurrentColor()
    {
        // ...
    }
}