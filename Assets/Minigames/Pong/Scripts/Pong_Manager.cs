using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Manager : MonoBehaviour
{
    public GameManager gameManager;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        if (gm != null)
            gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        if (gameManager != null)
        {
            gameManager.completedGoal = true;
            gameManager.command = "Defend!";
        }
    }

    public float GameSpeed()
    {
        if (gameManager != null)
            return gameManager.gameSpeed;
        else return 1;
    }
}