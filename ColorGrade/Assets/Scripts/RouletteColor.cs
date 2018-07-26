using UnityEngine;

public class RouletteColor
{
    public RouletteColor(int colorIndex, Color color, int maxColors)
    {
        float step = 360 / maxColors;
        rangeMin = step * colorIndex;
        rangeMax = step * (colorIndex + 1);
        currentColor = color;
    }

    private float rangeMin;
    public float RangeMin { get { return rangeMin; } }

    private float rangeMax;
    public float RangeMax { get { return rangeMax; } }

    private Color currentColor;
    public Color CurrentColor { get { return currentColor; } }
}