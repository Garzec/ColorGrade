using UnityEngine;

public class IngameMenu : Menu
{
    [SerializeField]
    GameObject ingameCanvas;

    public void Resume()
    {
        Time.timeScale = 1;
        ingameCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public override void BackToMainMenu()
    {
        Time.timeScale = 1;
        base.BackToMainMenu();
    }
}