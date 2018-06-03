using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Bullet : MonoBehaviour
{
    private Rigidbody bullet;
    public float speed = 20.0f;
    public float maxLifeTime = 1f;

    private void Start()
    {
        bullet = GetComponent<Rigidbody>();
        Destroy(gameObject, maxLifeTime);
    }

    private void Update()
    {
        Vector3 movement = -transform.up * speed * Time.deltaTime;
        bullet.MovePosition(bullet.position + movement);
    }
}