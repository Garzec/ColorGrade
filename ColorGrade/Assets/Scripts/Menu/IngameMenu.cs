using UnityEngine;

public class IngameMenu : Menu
{
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public override void BackToMainMenu()
    {
        Time.timeScale = 1;
        base.BackToMainMenu();
    }
}