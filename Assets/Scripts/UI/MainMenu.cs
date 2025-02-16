using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel; 
    [SerializeField] private GameObject aboutGamePanel; 

    private void Start()
    {
        aboutGamePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        // ѕереходим в сцену игры (—цена с индексом 1)
        SceneManager.LoadScene(1);
    }

    public void ShowAboutGamePanel()
    {
        aboutGamePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void HideAboutGamePanel()
    {
        aboutGamePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
