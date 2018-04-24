using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject ball = null;
    public float ballForce = 500;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 force = direction * ballForce;

        rb.AddForce(force.x, force.y, 0);
    }
}