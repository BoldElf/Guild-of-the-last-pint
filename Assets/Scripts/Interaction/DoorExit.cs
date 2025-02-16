using UnityEngine;

public class DoorExit : MonoBehaviour
{
    [SerializeField] private string[] requiredItems;
    [SerializeField] private CheckProofs checkProofs;
        
    

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
            Debug.Log("Вам чего-то не хватает.");
        }
    }
}
