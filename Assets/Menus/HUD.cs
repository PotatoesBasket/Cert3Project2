using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Gets lives, score, and command from the GameManager. Command is sent to GameManager from each MinigameManager.

    private HUD hud;
    private GameManager gameManager;

    public Image[] lives;
    public Image timer;
    public Text command;
    public Text score;
    public GameObject pausePanel;

    private Animation commandAni;
    private Animation timerAni;
    public float aniTimer;

    public void Awake()
    {
        KeepHUD();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        commandAni = command.GetComponent<Animation>();
        timerAni = timer.GetComponent<Animation>();
    }

    public void Update()
    {
        Text();
        Lives();
        Animations();
        Pause();
    }

    private void Text() //Updates HUD text.
    {
        command.text = gameManager.command;
        score.text = "Level: " + gameManager.score.ToString();
    }

    private void Lives() //Updates lives.
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i > gameManager.lives - 1)
                lives[i].color = new Color(0.22f, 0.22f, 0.22f, 0.8f);
            else
                lives[i].color = new Color(78f, 0.22f, 0.22f, 1f);
        }
    }

    private void Animations() //Plays command and timer animation at the start of each minigame.
    {
        aniTimer += Time.deltaTime * gameManager.gameSpeed;

        if (gameManager.playNewMGAni == true)
        {
            aniTimer = 0f;
            command.gameObject.SetActive(true);
            timer.gameObject.SetActive(true);
            commandAni["TextZoomIn"].speed = 1 * gameManager.gameSpeed;
            timerAni["TimerShrink"].speed = 1 * gameManager.gameSpeed;
            commandAni.Play();
            timerAni.Play();
            gameManager.playNewMGAni = false;
        }

        if (aniTimer >= 1.5f)
            command.gameObject.SetActive(false);

        if (aniTimer >= 4.95f)
            timer.gameObject.SetActive(false);
    }

    private void Pause()
    {
        if (gameManager.showPausePanel == true)
            pausePanel.gameObject.SetActive(true);
        else
            pausePanel.gameObject.SetActive(false);
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