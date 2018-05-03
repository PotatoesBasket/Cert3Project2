using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Ball : MonoBehaviour
{
    //Shoots ball in the same direction as the arrow (Golf_ArrowRotation).

    public GameObject ball;
    public GameObject arrow;
    public Golf_ArrowRotation rotation;

    void Start()
    {
        rotation = arrow.GetComponent<Golf_ArrowRotation>();
    }

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Fire1"))
            rb.AddForce(rotation.rotationAngle * 2, 0, 250);
    }
}