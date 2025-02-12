using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Vector3 boxSize = new Vector3(0.5f, 1f, 0.5f);
    [SerializeField] private Animator animator; // Аниматор игрока

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        bool isMoving = movement != Vector3.zero;

        // Управляем анимацией бега
        if (animator != null)
        {
            animator.SetBool("isRunning", isMoving);
        }

        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (CanMove(movement))
            {
                transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private bool CanMove(Vector3 direction)
    {
        // Проверяем наличие препятствий в направлении движения
        return !Physics.BoxCast(transform.position, boxSize / 2, direction, Quaternion.identity, moveSpeed * Time.deltaTime);
    }

    // Для визуализации области проверки в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
