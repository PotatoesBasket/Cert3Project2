using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navAgent;
    public float stopDistance = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if (distance > stopDistance)
        {
            navAgent.SetDestination(player.transform.position);
            navAgent.isStopped = false;
        }
        else
        {
            navAgent.isStopped = true;
        }
    }
}