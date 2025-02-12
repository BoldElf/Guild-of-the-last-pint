using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private Transform face;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private Animator playerAnimator; // Аниматор игрока

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
                    Debug.Log("Взаимодействие с объектом: " + hit.collider.name);

                    // Определяем новое состояние взаимодействия
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
                    Debug.Log("Объект не является местом для укрытия: " + hit.collider.name);
                }
            }
        }

        Debug.DrawRay(face.position, face.forward * interactionRange, Color.green);
    }

    private IEnumerator HideInSpot()
    {
        // Сразу отключаем управление движением
        GetComponent<PlayerMovement>().enabled = false;
        isInteracting = true;

        // Проигрываем анимацию игрока
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Interact");
        }

        // Ждем завершения анимации игрока
        yield return new WaitForSeconds(1.0f); // Замените на реальную длительность анимации

        // Отключаем модель игрока
        playerModel.SetActive(false);

        Debug.Log("Игрок спрятался.");

        // Сбрасываем флаг после завершения взаимодействия
        isInteracting = false;
    }

    private IEnumerator ExitFromSpot()
    {
        // Проигрываем анимацию игрока
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Interact");
        }

        // Ждем завершения анимации игрока
        yield return new WaitForSeconds(1.0f); // Замените на реальную длительность анимации

        // Включаем модель игрока
        playerModel.SetActive(true);

        // Включаем управление движением
        GetComponent<PlayerMovement>().enabled = true;

        Debug.Log("Игрок вышел из укрытия.");

        // Сбрасываем флаг после завершения взаимодействия
        isInteracting = false;
    }
}
