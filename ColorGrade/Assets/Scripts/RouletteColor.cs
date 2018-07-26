using UnityEngine;

public class RouletteColor
{
    public RouletteColor(int colorIndex, Color color, int maxColors)
    {
        float step = 360 / maxColors;
        colorRangeMin = step * colorIndex;
        colorRangeMax = step * (colorIndex + 1);
        currentColor = color;
    }

    private float colorRangeMin;
    public float ColorRangeMin { get { return colorRangeMin; } }

    private float colorRangeMax;
    public float ColorRangeMax { get { return colorRangeMax; } }

    private Color currentColor;
    public Color CurrentColor { get { return currentColor; } }
}