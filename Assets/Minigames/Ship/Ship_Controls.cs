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
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Ship_Manager>();
        player = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (manager.on == true)
        {
            moveInput = Input.GetAxis("Mouse X");
            movement = transform.right * (moveInput / 2.5f);

            if (Input.GetButtonDown("Fire1"))
                Fire();

#if UNITY_STANDALONE || UNITY_EDITOR
            player.MovePosition(new Vector3(Mathf.Clamp(player.position.x + movement.x, -9.9f, 9.9f), player.position.y, player.position.z));
#endif

#if UNITY_WEBGL
            player.MovePosition(new Vector3(Mathf.Clamp(player.position.x + movement.x / 2, -9.9f, 9.9f), player.position.y, player.position.z));
#endif
        }
    }
    
    private void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        manager.laser.Play();
    }
}