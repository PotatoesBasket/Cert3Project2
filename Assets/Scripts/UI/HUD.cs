using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Gets lives, score, and command from the GameManager. Command is sent to GameManager from each MinigameManager.

    private HUD hud;
    private GameManager gameManager;
    private Animation commandAni;
    public Text command;
    public Text lives;
    public Text score;
    public float aniTimer;

    public void Awake()
    {
        KeepHUD();
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
        commandAni = command.GetComponent<Animation>();
    }

    public void Update()
    {
        Text();
        CommandAnimation();
    }

    private void Text() //Updates HUD text.
    {
        command.text = gameManager.command;
        lives.text = gameManager.lives.ToString();
        score.text = gameManager.score.ToString();
    }

    private void CommandAnimation() //Plays command animation at the start of each minigame.
    {
        aniTimer += Time.deltaTime * gameManager.gameSpeed;

        if (gameManager.playCommandAni == true)
        {
            aniTimer = 0f;
            command.gameObject.SetActive(true);
            commandAni.Play();
            commandAni["TextZoomIn"].speed = 1 * gameManager.gameSpeed;
            gameManager.playCommandAni = false;
        }

        if (aniTimer >= 1.5f)
        {
            command.gameObject.SetActive(false);
        }
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