using System.Timers;
using UnityEngine;
using Zenject;

public class DoorExit : MonoBehaviour
{
    [SerializeField] private string[] requiredItems;
    [SerializeField] private CheckProofs checkProofs;
    [SerializeField] private GameObject noKeys;
    [SerializeField] private Canvas canvas;
    [Inject] DiContainer container;

    private GameObject noKeysPanel;

    private bool startTimer = false;
    private float timer = 0f;

    public void Interact(Transform playerBag)
    {
        bool hasAllItems = true;

        foreach (string itemName in requiredItems)
        {
            if (playerBag.Find(itemName) == null)
            {
                hasAllItems = false;
                break;
            }
        }

        if (hasAllItems)
        {
            Debug.Log("Вы сбежали.");
            checkProofs.checkFinal();
        }
        else
        {
            noKeysPanel = container.InstantiatePrefab(noKeys, canvas.transform);
            startTimer = true;
        }
    }

    private void Update()
    {
        if(startTimer == true)
        {
            timer += Time.deltaTime;

            if(timer >= 3f)
            {
                Destroy(noKeysPanel);
                timer = 0;
                startTimer = false;
            }
        }
    }
}
