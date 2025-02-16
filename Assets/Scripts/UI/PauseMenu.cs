using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; 
    [SerializeField] private GameObject resumeButton; 
    [SerializeField] private GameObject exitButton; 
    [SerializeField] private GameObject proofsButton; 
    [SerializeField] private GameObject proofsPanelPrefab; 
    private GameObject proofsPanelInstance;
    private bool isPaused = false;
    private bool isProofsPanelActive = false;

    private void Start()
    {
        pausePanel.SetActive(false);
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

            pausePanel.SetActive(true);
            Time.timeScale = 0; 
            AudioListener.pause = true; 
        }
        else
        {
            pausePanel.SetActive(false);
            if (proofsPanelInstance != null)
            {
                proofsPanelInstance.SetActive(false);
            }
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
        // Переходим в меню (Меню - это сцена с индексом 0)
        Time.timeScale = 1; 
        AudioListener.pause = false; 
        SceneManager.LoadScene(0);
    }

    public void ToggleProofsPanel()
    {
        isProofsPanelActive = !isProofsPanelActive;

        if (isProofsPanelActive)
        {
            if (proofsPanelInstance == null)
            {
                proofsPanelInstance = Instantiate(proofsPanelPrefab, pausePanel.transform);
            }
            proofsPanelInstance.SetActive(true);
        }
        else
        {
            if (proofsPanelInstance != null)
            {
                Destroy(proofsPanelInstance);
                proofsPanelInstance = null;
            }
        }
    }
}
