using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Enemy : MonoBehaviour
{
    //Makes the enemy walk toward the player at a speed affected by overall game speed.

    private Zombie_Manager manager;
    private GameObject player;
    private NavMeshAgent navAgent;
    private Animator animator;

    public float initialNavSpeed;
    public float initialAniSpeed;
    public float stopDistance = 2f;
    public bool isAttacking;
    public bool isHit;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Zombie_Manager>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        initialNavSpeed = navAgent.speed;
        initialAniSpeed = animator.speed;
    }

    private void Update()
    {
        Walk();
        Attack();
        Death();
        Animate();
    }

    private void Walk()
    {
        navAgent.speed = initialNavSpeed * manager.GameSpeed;
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

    private void Attack()
    {
        if (navAgent.isStopped == true && isHit == false)
        {
            isAttacking = true;
        }
    }

    private void Death()
    {
        if (isHit == true)
        {
            navAgent.isStopped = true;
        }
    }

    private void Animate()
    {
        animator.speed = initialAniSpeed * manager.GameSpeed;

        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isHit", isHit);
    }
}