using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Manager : MonoBehaviour
{
    public GameManager gameManager;
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
        gameManager.gameOver = false;
    }
}