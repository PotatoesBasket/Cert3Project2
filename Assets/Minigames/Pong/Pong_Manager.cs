using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();

        gameManager.command = "Defend!";
        gameManager.completedGoal = true; //Pong_PlayerGoal
    }
}