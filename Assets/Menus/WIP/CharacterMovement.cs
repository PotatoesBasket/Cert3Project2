using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Enables the player to move and applies gravity.

    private Transform player;
    private CharacterController controller;

    public float forwardSpeed = 10f;
    public float strafeSpeed = 8f;
    public float gravity = 30f;

    private void Awake()
    {
        player = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Gravity();
    }

    private void Move() //Move character, up/down = forward/backward, left/right = strafe. Rotation is controlled by FirstPersonCamera.cs.
    {
        float zMove = Input.GetAxis("Vertical");
        float xMove = Input.GetAxis("Horizontal");

        Vector3 moveForward = player.forward * zMove * forwardSpeed * Time.deltaTime;
        Vector3 moveStrafe = player.right * xMove * strafeSpeed * Time.deltaTime;

        controller.Move(moveForward + moveStrafe);
    }

    private void Gravity() //Applies gravity effect.
    {
        Vector3 move = new Vector3(0, -gravity, 0);
        controller.Move(move * Time.deltaTime);
    }
}