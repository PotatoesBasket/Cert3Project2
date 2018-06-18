using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public float GameSpeed { get { return gameManager.gameSpeed; } }
    public bool on = true;

    public AudioSource putt;
    public AudioSource goal;
    public AudioSource clap;
    public bool hasShot = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.command = "Putt!";
        gameManager.completedGoal = false; //Golf_Hole
    }

    private void Update()
    {
        if (gameManager.isPaused == true)
            on = false;
        else if (hasShot == false)
            on = true;
    }
}