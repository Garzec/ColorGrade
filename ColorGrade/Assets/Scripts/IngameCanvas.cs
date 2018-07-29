using UnityEngine;

public class IngameCanvas : MonoBehaviour
{
    [SerializeField]
    Observer observer;

    [SerializeField]
    GameObject ingameMenu;

    private void Start()
    {
        ingameMenu.SetActive(false);
    }

    public void DropBall()
    {
        observer.EnableBallDrop();
    }

    public void OpenIngameMenu()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}