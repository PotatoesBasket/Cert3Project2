using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_AutoDrive : MonoBehaviour
{
    //Moves rigidbody forward automatically and allows for turning with the mouse's horizontal axis.

    //WIP - No mouse controls yet. Turn with A and D.

    public Rigidbody rigid;

    public bool on = true;
    public float speed = 20.0f;
    public float turnSpeed = 100.0f;
    private float turnInput;

    void Update()
    {
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (on == true)
        {
            Move();
            Turn();
        }
    }

    private void Move()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);
    }

    private void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigid.MoveRotation(rigid.rotation * turnRotation);
    }
}