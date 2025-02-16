using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class EnemyDetectController : MonoBehaviour
{
    [Inject] private DiContainer _container;
    private bool detect = false;

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Canvas canvas;

    private GameObject buttonRestart;

    public void playerDetect()
    {
        if(detect == false)
        {
            Time.timeScale = 0;

            buttonRestart = _container.InstantiatePrefab(buttonPrefab, canvas.transform);
            buttonRestart.GetComponent<Button>().onClick.AddListener(Restart);
            Debug.Log("Player detect");
            detect = true;
        }
        
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
