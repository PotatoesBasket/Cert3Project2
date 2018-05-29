using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Manager : MonoBehaviour
{
    //Manager for car minigame.
    //Conditions for failure located in Car_Collision.

    public GameManager gameManager;
    public bool on = true;

    public float GameSpeed { get { return gameManager.gameSpeed; } }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.command = "Avoid!";
        gameManager.completedGoal = true;
        gameManager.minigameOver = false;
    }
}