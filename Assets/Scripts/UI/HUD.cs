using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Gets lives, score, and command from the GameManager. Command is sent to GameManager from each MinigameManager.

    private HUD hud;
    private GameManager gameManager;
    public Text command;
    public Text lives;
    public Text score;

    public void Awake()
    {
        KeepHUD();
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    public void Update()
    {
        command.text = gameManager.command;
        lives.text = gameManager.lives.ToString();
        score.text = gameManager.score.ToString();
    }

    private void KeepHUD() //Keeps the HUD across scenes.
    {
        if (hud == null)
            hud = this;
        else if (hud != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}