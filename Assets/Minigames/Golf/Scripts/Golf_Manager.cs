using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Manager : MonoBehaviour
{
    //Win state activated in Golf_Hole.

    private GameManager gameManager;

    public float GameSpeed { get { return gameManager.gameSpeed; } }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.completedGoal = false;
        gameManager.command = "Putt!";
    }
}