using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public bool isOccupied = false; // Флаг, указывающий, занято ли укрытие
    public Animator animator; // Компонент Animator для управления анимациями

    private void Start()
    {
        // Если Animator не назначен, пытаемся получить его из текущего объекта
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
        // Устанавливаем новое состояние
        isOccupied = newState;

        // Выводим сообщение в зависимости от состояния
        if (isOccupied)
        {
            Debug.Log("Игрок спрятался в " + gameObject.name);
        }
        else
        {
            Debug.Log("Игрок вышел из " + gameObject.name);
        }

        // Проигрываем анимацию
        if (animator != null)
        {
            animator.SetTrigger("Interact");
        }
    }
}
