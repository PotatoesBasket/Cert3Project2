using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_EnemySpawn : MonoBehaviour
{
    //Places the enemy in either the left or right spawn position randomly.

    private Rigidbody enemy;
    public Transform left;
    public Transform right;
    private bool leftSpawn;

    private void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        leftSpawn = (Random.value > 0.5f);
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (leftSpawn == true)
        {
            enemy.transform.localPosition = left.position;
        }

        if (leftSpawn == false)
        {
            enemy.transform.localPosition = right.position;
        }
    }
}