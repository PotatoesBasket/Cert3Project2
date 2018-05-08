using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    private Rigidbody paddle;
    public Vector3 movement;
    public float moveInput;

    void Start()
    {
        paddle = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Mouse Y");
        movement = transform.right * moveInput;
        paddle.position = new Vector3(paddle.position.x, Mathf.Clamp(paddle.position.y, -9.5f, 9.5f), paddle.position.z);
    }

    private void FixedUpdate()
    {
        paddle.MovePosition(paddle.position + movement * 2);
    }
}