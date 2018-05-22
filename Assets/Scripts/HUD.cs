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
    public Text command;
    public Text score;
    public Text timer;

    private Animation commandAni;
    public float aniTimer;

    public void Awake()
    {
        KeepHUD();
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
        commandAni = command.GetComponent<Animation>();
    }

    public void Start()
    {
        for (int i = 0; i < gameManager.lives; i++)
            lives[i].color = new Color(1f, 0.42f, 0.25f, 1f);
    }

    public void Update()
    {
        Text();
        Lives();
        CommandAnimation();
    }

    private void Text() //Updates HUD text.
    {
        command.text = gameManager.command;
        score.text = gameManager.score.ToString();
    }

    private void Lives() //Updates lives.
    {
        for (int i = 3; i + 1 > gameManager.lives && gameManager.lives > 0; i--)
        {
            lives[i].color = new Color(0.22f, 0.22f, 0.22f, 1f);
        }
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