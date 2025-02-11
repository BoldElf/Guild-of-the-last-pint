using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Zenject.SpaceFighter;
using Zenject;

public class EnemyDetect : MonoBehaviour
{
    
    [Inject] private EnemyDetectController enemyDetectController;

    [SerializeField] private int distance = 33;
    [SerializeField] private LineRenderer lineRenderer;

    private int layer = ~0; // Проверка всех слоев.

    private void Start()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.2f;
    }

    private void Update()
    {
        RaycastHit hit;
        // Рейкаст для отслеживания.
        Ray ray = new Ray(gameObject.transform.position, transform.forward);

        // Проверка попадания
        if (Physics.Raycast(ray, out hit, distance, layer, QueryTriggerInteraction.Ignore))
        {
            //Debug.Log(hit.collider.gameObject);                 // DBG

            if (hit.collider.gameObject.GetComponent<EnemyDetector>() == true)
            {
                EnemyDetectPlayer();
            }

            //Debug.DrawLine(ray.origin, hit.point, Color.red);   // DBG

            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    private void EnemyDetectPlayer()
    {
        enemyDetectController.playerDetect();
    }
}
