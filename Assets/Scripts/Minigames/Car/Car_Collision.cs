using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Collision : MonoBehaviour
{
    //Turns the car controls off when it collides with something and tells the GameManager you failed the game.

    //Goes through the Minigame Manager to access rigidbodies/bools/whatever. Probably not the best way to do this.

    private Car_Manager manager;
    private Car_AutoDrive drive;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("MiniManager");
        manager = gm.GetComponent<Car_Manager>();
        drive = GetComponent<Car_AutoDrive>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.Equals(manager.leftBoundary) || collision.rigidbody.Equals(manager.rightBoundary))
        {
            manager.gameManager.completedGoal = false;
            drive.on = false;
        }
    }
}