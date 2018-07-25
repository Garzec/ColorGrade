using UnityEngine;
using UnityEngine.UI;

public class IngameHighscore : MonoBehaviour
{
    [SerializeField]
    private Text txt;

    private void Start()
    {
        SetHighscore();
    }

    private void SetHighscore()
    {
        txt.text = GetHighscore().ToString();
    }

    private int GetHighscore()
    {
        return PlayerPrefs.GetInt("Highscore1");
    }
}