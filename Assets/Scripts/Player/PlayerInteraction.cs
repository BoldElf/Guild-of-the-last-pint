using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private Transform face;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private Animator playerAnimator; // �������� ������

    private bool isInteracting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            Ray ray = new Ray(face.position, face.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                HidingSpot hidingSpot = hit.collider.GetComponent<HidingSpot>();

                if (hidingSpot != null)
                {
                    hidingSpot.Interact();
                    Debug.Log("�������������� � ��������: " + hit.collider.name);

                    // ���������� ����� ��������� ��������������
                    if (hidingSpot.isOccupied)
                    {
                        StartCoroutine(HideInSpot());
                    }
                    else
                    {
                        StartCoroutine(ExitFromSpot());
                    }
                }
                else
                {
                    Debug.Log("������ �� �������� ������ ��� �������: " + hit.collider.name);
                }
            }
        }

        Debug.DrawRay(face.position, face.forward * interactionRange, Color.green);
    }

    private IEnumerator HideInSpot()
    {
        // ����� ��������� ���������� ���������
        GetComponent<PlayerMovement>().enabled = false;
        isInteracting = true;

        // ����������� �������� ������
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Interact");
        }

        // ���� ���������� �������� ������
        yield return new WaitForSeconds(1.0f); // �������� �� �������� ������������ ��������

        // ��������� ������ ������
        playerModel.SetActive(false);

        Debug.Log("����� ���������.");

        // ���������� ���� ����� ���������� ��������������
        isInteracting = false;
    }

    private IEnumerator ExitFromSpot()
    {
        // ����������� �������� ������
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Interact");
        }

        // ���� ���������� �������� ������
        yield return new WaitForSeconds(1.0f); // �������� �� �������� ������������ ��������

        // �������� ������ ������
        playerModel.SetActive(true);

        // �������� ���������� ���������
        GetComponent<PlayerMovement>().enabled = true;

        Debug.Log("����� ����� �� �������.");

        // ���������� ���� ����� ���������� ��������������
        isInteracting = false;
    }
}
