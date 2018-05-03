using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody plate;
    public Rigidbody food;

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.completedGoal = false;
        gameManager.command = "Catch!";
    }
}