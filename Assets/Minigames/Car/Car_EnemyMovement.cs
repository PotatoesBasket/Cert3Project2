using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_EnemyMovement : MonoBehaviour
{
    //Moves enemy cars.

    public Rigidbody enemy;
    public float speed = 10.0f;

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        enemy.MovePosition(enemy.position + movement);
    }
}