using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour
{
    protected void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void StartGame()
    {
        LoadScene("Ingame");
    }

    public void LoadHighscores()
    {
        LoadScene("Highscore");
    }

    public virtual void BackToMainMenu()
    {
        LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}