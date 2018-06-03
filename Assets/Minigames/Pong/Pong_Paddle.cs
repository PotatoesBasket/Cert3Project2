using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    private Rigidbody paddle;
    private Vector3 movement;
    private float moveInput;

    private void Awake()
    {
        paddle = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Mouse Y");
        movement = transform.right * moveInput;
    }

    private void FixedUpdate()
    {
        paddle.MovePosition(new Vector3(paddle.position.x, Mathf.Clamp(paddle.position.y + movement.y, -9.9f, 9.9f), paddle.position.z));
    }
}