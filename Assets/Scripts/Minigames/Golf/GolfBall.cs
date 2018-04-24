using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject arrow;
    public ArrowRotation rotation;

    void Start()
    {
        rotation = arrow.GetComponent<ArrowRotation>();
    }

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Fire1"))
            rb.AddForce(rotation.rotationAngle * 2, 0, 250);
    }
}