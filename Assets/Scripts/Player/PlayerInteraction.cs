using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private Transform face; 
    [SerializeField] private GameObject playerModel; 

    private bool isInteracting = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(face.position, face.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                HidingSpot hidingSpot = hit.collider.GetComponent<HidingSpot>();

                if (hidingSpot != null)
                {
                    hidingSpot.Interact();
                    Debug.Log("Взаимодействие с объектом: " + hit.collider.name);

                    if (hidingSpot.isOccupied)
                    {
                        HidePlayer();
                    }
                    else
                    {
                        ExitHidingSpot();
                    }
                }
                else
                {
                    Debug.Log("Объект не является местом для укрытия: " + hit.collider.name);
                }
            }
        }

        Debug.DrawRay(face.position, face.forward * interactionRange, Color.green);
    }

    private void HidePlayer()
    {
        playerModel.SetActive(false);

        GetComponent<PlayerMovement>().enabled = false;

        isInteracting = true;
    }

    private void ExitHidingSpot()
    {
        playerModel.SetActive(true);

        GetComponent<PlayerMovement>().enabled = true;

        isInteracting = false;
    }
}
