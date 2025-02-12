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
        // ������ ��� �������� ������
        isOccupied = true;
        Debug.Log("����� ��������� � " + gameObject.name);
    }

    private void ExitHidingSpot()
    {
        // ������ ��� ������ �� �������
        isOccupied = false;
        Debug.Log("����� ����� �� " + gameObject.name);
    }
}
