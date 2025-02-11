using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float collisionOffset = 0.5f; 
    [SerializeField] private Transform face; 
    [SerializeField] private Vector3 boxSize = new Vector3(0.5f, 1f, 0.5f); 

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (CanMove(movement))
            {
                transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            }
        }

        //Œ“Œ¡–¿∆≈Õ». Õ≈ «¿¡€“‹ ”¡–¿“‹
        Debug.DrawRay(face.position, movement * collisionOffset, Color.red);
    }

    private bool CanMove(Vector3 direction)
    {
        RaycastHit hit;
        return !Physics.BoxCast(transform.position, boxSize / 2, direction, out hit, Quaternion.identity, collisionOffset);
    }

    //Õ≈ «¿¡€“‹ ”¡–¿“‹/»— Àﬁ◊»“‹
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
