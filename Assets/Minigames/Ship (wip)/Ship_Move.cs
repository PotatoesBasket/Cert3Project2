using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Move : MonoBehaviour
{
    private Rigidbody player;
    private Vector3 movement;
    private float moveInput;

    private void Awake()
    {
        player = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        moveInput = Input.GetAxis("Mouse X");
        movement = transform.right * moveInput;
    }

    private void FixedUpdate()
    {
        player.MovePosition(new Vector3(Mathf.Clamp(player.position.x + movement.x, -10, 10), player.position.y, player.position.z));
    }
}