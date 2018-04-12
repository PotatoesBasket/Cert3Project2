using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    //Enables the player to move and jump.

    private CharacterController cc;
    public float inputDelay = 0.1f;

    public float speed = 10f;
    public float gravity = 20f;
    public float jumpSpeed = 10f;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move() //Move character, up/down = forward/backward, left/right = strafe.
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cc.Move(move * speed * Time.deltaTime);
    }

    private void Jump() //Jump.
    {
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {

        }
    }
}
