using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_FoodCollisions : MonoBehaviour
{
    private Catch_Manager manager;
    public Collider floor;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Catch_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.gameManager.completedGoal = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        manager.on = false;
        manager.clap.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == floor)
        {
            manager.hasFailed = true;
            manager.on = false;
        }
    }
}