using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public bool isOccupied = false; 

    public void Interact()
    {
        if (!isOccupied)
        {
            HidePlayer();
        }
        else
        {
            ExitHidingSpot();
        }
    }

    private void HidePlayer()
    {
        // Логика для прятания игрока
        isOccupied = true;
        Debug.Log("Игрок спрятался в " + gameObject.name);
    }

    private void ExitHidingSpot()
    {
        // Логика для выхода из укрытия
        isOccupied = false;
        Debug.Log("Игрок вышел из " + gameObject.name);
    }
}
