using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.AI;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform patroleRote;

    private List<Transform> targets = new List<Transform>();

    private int localIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        InitializePatroleRoute();

        MoveToNextLocation();
    }

    private void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextLocation();
        }
    }

    private void InitializePatroleRoute()
    {
        foreach(Transform route in patroleRote)
        {
            targets.Add(route);
        }
    }

    private void MoveToNextLocation()
    {
        if(targets.Count > 0)
        {
            agent.destination = targets[localIndex].position;
            localIndex = (localIndex + 1) % targets.Count;
        }
    }
}
