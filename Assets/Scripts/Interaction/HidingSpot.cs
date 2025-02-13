using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public bool isOccupied = false;
    public Animator animator; 

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void Interact()
    {
        // Инвертируем состояние isOccupied
        bool newState = !isOccupied;
        HandleInteraction(newState);
    }

    private void HandleInteraction(bool newState)
    {
        isOccupied = newState;

        if (isOccupied)
        {
            Debug.Log("Игрок спрятался в " + gameObject.name);
        }
        else
        {
            Debug.Log("Игрок вышел из " + gameObject.name);
        }

        if (animator != null)
        {
            animator.SetTrigger("Interact");
        }
    }
}
