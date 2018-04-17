using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    //Enables the player to move and jump.

    private Transform player;
    private CharacterController controller;

    public float forwardSpeed = 10f;
    public float strafeSpeed = 8f;

    public float gravity = 30f;
    private bool canJump = false;
    private bool isJumping = false;
    private bool isFalling = false;

    private void Awake()
    {
        player = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move() //Move character, up/down = forward/backward, left/right = strafe. Rotation is controlled by FirstPersonCamera.cs.
    {
        float zMove = Input.GetAxis("Vertical");
        float xMove = Input.GetAxis("Horizontal");

        Vector3 moveForward = player.forward * zMove * forwardSpeed * Time.deltaTime;
        Vector3 moveStrafe = player.right * xMove * strafeSpeed * Time.deltaTime;

        controller.Move(moveForward + moveStrafe);
    }

    //WIP
    private void Jump() //Jumping and gravity effect.
    {
        float jumpInput = 0;
        float maxJumpInput = 20;

        if (controller.isGrounded)
            canJump = true;

        if (Input.GetButton("Jump") && jumpInput <= maxJumpInput)
        {
            jumpInput += Time.deltaTime;
        }
        else
        {
            jumpInput -= Time.deltaTime;
        }

        Vector3 move = new Vector3(0, -gravity, 0);
        controller.Move(move * Time.deltaTime);
    }
}
