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
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            paddle.MovePosition(new Vector3(paddle.position.x, Mathf.Clamp(paddle.position.y + movement.y, -9.9f, 9.9f), paddle.position.z));
#endif

#if UNITY_WEBGL
            paddle.MovePosition(new Vector3(paddle.position.x, Mathf.Clamp(paddle.position.y + movement.y / 2, -9.9f, 9.9f), paddle.position.z));
#endif
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        manager.paddle.Play();
    }
}