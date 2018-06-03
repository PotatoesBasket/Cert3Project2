using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }
    public bool on = true;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();

        gameManager.command = "Avoid!";
        gameManager.completedGoal = true; //Car_Collision
    }

    private void Update()
    {
        if (gameManager.isPaused == true)
            on = false;
        else if (gameManager.completedGoal == true)
            on = true;
    }
}