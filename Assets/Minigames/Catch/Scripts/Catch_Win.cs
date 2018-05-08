using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Win : MonoBehaviour
{
    //Tells the GameManager you won.

    private Catch_Manager manager;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("MiniManager");
        manager = gm.GetComponent<Catch_Manager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.Equals(manager.food))
        {
            manager.gameManager.completedGoal = true;
            manager.food.isKinematic = true;
            manager.controlsOn = false;
        }
    }
}