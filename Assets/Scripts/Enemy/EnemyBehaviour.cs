using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform patrolRoute;
    [SerializeField] private AudioClip movingSound; 
    private List<Transform> targets = new List<Transform>();
    private int localIndex = 0;
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private bool isPlayingMovingSound = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = movingSound;
        audioSource.loop = true; 

        InitializePatrolRoute();
        MoveToNextLocation();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextLocation();
        }

        if (agent.velocity.magnitude > 0.1f)
        {
            if (!isPlayingMovingSound)
            {
                audioSource.Play();
                isPlayingMovingSound = true;
            }
        }
        else
        {
            if (isPlayingMovingSound)
            {
                audioSource.Stop();
                isPlayingMovingSound = false;
            }
        }
    }

    private void InitializePatrolRoute()
    {
        foreach (Transform route in patrolRoute)
        {
            targets.Add(route);
        }
    }

    private void MoveToNextLocation()
    {
        if (targets.Count > 0)
        {
            agent.destination = targets[localIndex].position;
            localIndex = (localIndex + 1) % targets.Count;
        }
    }
}
