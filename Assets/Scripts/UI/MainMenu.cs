using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel; 
    [SerializeField] private GameObject aboutGamePanel; 
    [SerializeField] private int gameSceneIndex = 1; 

    private void Start()
    {
        aboutGamePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
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
