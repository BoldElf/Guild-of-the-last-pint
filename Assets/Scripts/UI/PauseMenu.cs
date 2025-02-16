using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton; 
    [SerializeField] private GameObject resumeButton; 
    [SerializeField] private GameObject exitButton; 
    private bool isPaused = false;

    private void Start()
    {
        resumeButton.SetActive(false);
        exitButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
            exitButton.SetActive(true);
            Time.timeScale = 0; 
            AudioListener.pause = true; 
        }
        else
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
            exitButton.SetActive(false);
            Time.timeScale = 1; 
            AudioListener.pause = false; 
        }
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void ExitToMenu()
    {
        // Ïåğåõîäèì â ìåíş (ÑÖÅÍÀ ÌÅÍŞ ÄÎËÆÍÀ ÁÛÒÜ ÏÎÄ ÈÍÄÅÊÑÎÌ 0!!!)
        Time.timeScale = 1;
        AudioListener.pause = false; 
        SceneManager.LoadScene(0);
    }
}
