using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Gets lives, score, and command from the GameManager. Command is sent to GameManager from each MinigameManager.

    private GameManager gameManager;
    public Text command;
    public Text lives;
    public Text score;

    public void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    public void Update()
    {
        command.text = gameManager.command;
        lives.text = gameManager.lives.ToString();
        score.text = gameManager.score.ToString();
    }
}