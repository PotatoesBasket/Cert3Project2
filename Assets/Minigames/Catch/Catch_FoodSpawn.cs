using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_FoodSpawn : MonoBehaviour
{
    private Rigidbody food;
    private float xPos;
    private float zPos;
    private Vector3 spawnPos;

    private void Start()
    {
        food = GetComponent<Rigidbody>();
        xPos = Random.Range(-15, 15);
        zPos = Random.Range(-5, 30);
        spawnPos = new Vector3(xPos, food.transform.position.y, zPos);
        food.MovePosition(spawnPos);
    }
}