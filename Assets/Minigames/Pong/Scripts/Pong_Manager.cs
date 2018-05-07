using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Manager : MonoBehaviour
{
    private GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.completedGoal = true;
        gameManager.command = "Defend!";
    }
}