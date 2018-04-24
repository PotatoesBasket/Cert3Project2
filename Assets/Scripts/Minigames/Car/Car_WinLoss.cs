using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_WinLoss : MonoBehaviour
{
    //Controls the Car minigame's win/lose conditions. Attached to the car.

    public Rigidbody car;
    public Rigidbody leftBoundary;
    public Rigidbody rightBoundary;
    private GameManager gameManager;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
        gameManager.completedGoal = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.completedGoal = false;
    }
}