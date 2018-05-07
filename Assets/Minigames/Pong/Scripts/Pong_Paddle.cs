using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    private Rigidbody paddle;
    public Rigidbody topWall;
    public Rigidbody bottomWall;
    private float moveInput;

    void Start()
    {
        paddle = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = transform.right * moveInput;
        paddle.MovePosition(paddle.position + movement);
    }
}