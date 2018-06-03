using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_FoodCollisions : MonoBehaviour
{
    private Catch_Manager manager;
    public Collider floor;
    public Collider plate;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("MiniManager");
        manager = gm.GetComponent<Catch_Manager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.Equals(plate))
        {
            manager.gameManager.completedGoal = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            manager.on = false;
            manager.clap.Play();
        }
    }
}