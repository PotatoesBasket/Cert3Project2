using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Shooting : MonoBehaviour
{
    private RaycastHit hit;
    private Zombie_Manager manager;
    private GameObject inRange;
    private float rayDistance = 50;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Zombie_Manager>();
        inRange = null;
    }

    private void Update()
    {
        EnemyInRange();
        Shoot();
        DebugTools();
    }

    private void EnemyInRange() //Sets inRange to whatever object is within range.
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance) && hit.rigidbody != null)
            inRange = hit.rigidbody.gameObject;
        else
            inRange = null;
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && inRange != null)
        {
            inRange.GetComponent<Zombie_Enemy>().isHit = true;
        }
    }

    private void DebugTools()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        else
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.white);
    }
}