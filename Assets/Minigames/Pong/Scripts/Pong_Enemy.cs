using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Enemy : MonoBehaviour
{
    private Rigidbody enemy;
    public Rigidbody ball;

    private void Start()
    {
        enemy = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, ball.transform.position.y);
    }
}