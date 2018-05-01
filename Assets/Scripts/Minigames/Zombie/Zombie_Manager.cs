using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Manager : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.completedGoal = true;
        gameManager.command = "Survive!";
    }
}