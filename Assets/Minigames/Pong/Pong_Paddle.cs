using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    private Pong_Manager manager;
    private Rigidbody paddle;
    private Vector3 movement;
    private float moveInput;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Pong_Manager>();
        paddle = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (manager.on == true)
        {
            moveInput = Input.GetAxis("Mouse Y");
            movement = transform.right * moveInput;
        }
    }

    private void FixedUpdate()
    {
        if (manager.on == true)
            paddle.MovePosition(new Vector3(paddle.position.x, Mathf.Clamp(paddle.position.y + movement.y, -9.9f, 9.9f), paddle.position.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        manager.paddle.Play();
    }
}