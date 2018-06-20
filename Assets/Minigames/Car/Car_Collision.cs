using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Collision : MonoBehaviour
{
    //Freezes car and object it collides with and tells the GameManager you failed the game.

    private Car_Manager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Car_Manager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            manager.gameManager.completedGoal = false;
            manager.on = false;
            manager.engine.Stop();
            manager.crash.Play();
            collision.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}