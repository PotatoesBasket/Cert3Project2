using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Manager : MonoBehaviour
{
    private GameManager gameManager;
    public Rigidbody car;
    public Rigidbody leftBoundary;
    public Rigidbody rightBoundary;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.completedGoal = true;
        gameManager.command = "Avoid!";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.Equals(leftBoundary) || collision.rigidbody.Equals(rightBoundary))
        {
            gameManager.completedGoal = false;
        }
    }
}