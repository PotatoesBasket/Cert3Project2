using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }
    public bool on = true;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.command = "Pack!";
        gameManager.completedGoal = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (gameManager.isPaused == true)
            on = false;
        else if (gameManager.completedGoal == false)
            on = true;
    }
}