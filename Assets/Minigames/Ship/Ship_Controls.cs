using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Controls : MonoBehaviour
{
    private Ship_Manager manager;
    private Rigidbody player;
    private Vector3 movement;
    private float moveInput;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Ship_Manager>();
        player = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (manager.on == true)
        {
            moveInput = Input.GetAxis("Mouse X");
            movement = transform.right * moveInput;

            if (Input.GetButtonDown("Fire1"))
                Fire();

            player.MovePosition(new Vector3(Mathf.Clamp(player.position.x + movement.x, -10, 10), player.position.y, player.position.z));
        }
    }
    
    private void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}