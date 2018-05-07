using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Ball : MonoBehaviour
{
    private Pong_Manager manager;
    private Rigidbody ball;
    private float ballForce = 500;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Pong_Manager>();
    }

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 force = direction * ballForce * manager.GameSpeed;

        ball.AddForce(force.x, force.y, 0);
    }
}