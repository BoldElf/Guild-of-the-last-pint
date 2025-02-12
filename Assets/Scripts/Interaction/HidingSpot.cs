using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public bool isOccupied = false; // ����, �����������, ������ �� �������
    public Animator animator; // ��������� Animator ��� ���������� ����������

    private void Start()
    {
        // ���� Animator �� ��������, �������� �������� ��� �� �������� �������
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void Interact()
    {
        // ����������� ��������� isOccupied
        bool newState = !isOccupied;
        HandleInteraction(newState);
    }

    private void HandleInteraction(bool newState)
    {
        // ������������� ����� ���������
        isOccupied = newState;

        // ������� ��������� � ����������� �� ���������
        if (isOccupied)
        {
            Debug.Log("����� ��������� � " + gameObject.name);
        }
        else
        {
            Debug.Log("����� ����� �� " + gameObject.name);
        }

        // ����������� ��������
        if (animator != null)
        {
            animator.SetTrigger("Interact");
        }
    }
}
