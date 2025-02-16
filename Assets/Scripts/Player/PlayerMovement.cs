using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Vector3 boxSize = new Vector3(0.5f, 1f, 0.5f);
    [SerializeField] private Vector3 boxOffset = Vector3.zero;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip runningSound;
    private AudioSource audioSource;
    private bool isPlayingRunningSound = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = runningSound;
        audioSource.loop = true; 
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        bool isMoving = movement != Vector3.zero;

        if (animator != null)
        {
            animator.SetBool("isRunning", isMoving);
        }

        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Vector3 desiredMovement = movement * moveSpeed * Time.deltaTime;
            Vector3 actualMovement = AdjustMovementForCollisions(desiredMovement);

            transform.Translate(actualMovement, Space.World);

            if (!isPlayingRunningSound)
            {
                audioSource.Play();
                isPlayingRunningSound = true;
            }
        }
        else
        {
            if (isPlayingRunningSound)
            {
                audioSource.Stop();
                isPlayingRunningSound = false;
            }
        }
    }

    private Vector3 AdjustMovementForCollisions(Vector3 desiredMovement)
    {
        Vector3 boxPosition = transform.position + boxOffset;
        RaycastHit hit;

        if (Physics.BoxCast(boxPosition, boxSize / 2, desiredMovement, out hit, Quaternion.identity, desiredMovement.magnitude))
        {
            Vector3 adjustedMovement = Vector3.ProjectOnPlane(desiredMovement, hit.normal);

            if (Physics.BoxCast(boxPosition, boxSize / 2, adjustedMovement, Quaternion.identity, adjustedMovement.magnitude))
            {
                return Vector3.zero;
            }

            return adjustedMovement;
        }

        return desiredMovement;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + boxOffset, boxSize);
    }
}
