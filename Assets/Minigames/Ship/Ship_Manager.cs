using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }
    public bool on = true;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();

        gameManager.command = "Shoot!";
        gameManager.completedGoal = false; //Ship_EnemyDeath
    }

    private void Update()
    {
        if (gameManager.isPaused == true)
            on = false;
        else if (gameManager.completedGoal == false)
            on = true;
    }
}