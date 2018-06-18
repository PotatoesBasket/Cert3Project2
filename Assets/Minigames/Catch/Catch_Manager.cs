using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }
    public bool on = true;

    public AudioSource clap;
    public bool hasFailed = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.command = "Catch!";
        gameManager.completedGoal = false; //Catch_FoodCollisions
    }

    private void Update()
    {
        if (gameManager.isPaused == true)
            on = false;
        else if (hasFailed == false && gameManager.completedGoal == false)
            on = true;
    }
}