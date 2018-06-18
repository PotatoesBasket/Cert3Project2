using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Ball : MonoBehaviour
{
    private Pong_Manager manager;
    private Rigidbody ball;
    private float ballForce = 1000;

    public Collider topWall;
    public Collider bottomWall;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Pong_Manager>();
        ball = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Vector2 direction = new Vector2(1, Random.Range(-0.5f, 0.5f));
        Vector2 force = direction * ballForce * manager.GameSpeed;
        ball.AddForce(force.x, force.y, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == topWall || collision.collider == bottomWall)
            manager.wall.Play();
    }
}