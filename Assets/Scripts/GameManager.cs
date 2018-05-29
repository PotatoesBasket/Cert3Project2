using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public float gameSpeed;
    public float gameTimer;
    public float transitionTimer;
    public float gameTimeLimit;
    public float transitionTimeLimit;
    public string command;
    public int lives;
    public int score;
    public int freeLifeCounter;

    public bool completedGoal = false;
    public bool minigameOver = false;
    public bool gameOver = false;
    public bool playCommandAni = false;

    public enum GameState
    {
        TitleScreen,
        Game,
        Pause
    }
    public GameState gameState;

    public enum MinigameList
    {
        Golf,
        Car,
        Catch,
        Zombie,
        Pong
    }
    public MinigameList prevGame;
    public MinigameList currentGame;
    public MinigameList nextGame;

    private void Awake()
    {
        KeepGameManager();
    }

    private void Start()
    {
        gameState = GameState.TitleScreen;
        NewGameValues();
    }

    private void Update()
    {
        GameTimer();
        FreeLife();

        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }


    //---------------------------------------------------------------------v

    public void NewGameValues()
    {
        gameTimeLimit = 5f;
        transitionTimer = 0f;
        transitionTimeLimit = 3f;
        gameSpeed = 0.98f;
        lives = 4;
        score = 0;
        freeLifeCounter = 0;
        NewMinigameValues();
    }

    private void NewMinigameValues()
    {
        gameTimer = 0f;
        gameSpeed += 0.01f;
        playCommandAni = true;
        minigameOver = false;
        prevGame = currentGame;
    }

    private void GameTimer()
    {
        if (gameState == GameState.Game)
        {
            gameTimer += gameSpeed * Time.deltaTime;

            if (gameTimer >= gameTimeLimit)
                minigameOver = true;

            if (minigameOver == true)
                OnMinigameFinish();
        }
    }

    private void OnMinigameFinish()
    {
        AddToScore();
        if (completedGoal == false)
            LoseLife();

        SwitchGame();
    }

    public void SwitchGame()
    {
        NewMinigameValues();

        bool generateNextGame;
        generateNextGame = false;

        if (generateNextGame == false)
        {
            currentGame = nextGame;
            SceneManager.LoadScene(nextGame.ToString());
            generateNextGame = true;
        }

        if (generateNextGame == true)
        {
            do { nextGame = GetRandomGame<MinigameList>(); }
            while (nextGame == currentGame || nextGame == prevGame);

            generateNextGame = false;
        }
    }

    private void FreeLife()
    {
        if (freeLifeCounter == 25)
        {
            if (lives < 4)
                lives += 1;
            freeLifeCounter = 0;
        }
    }

    private void AddToScore()
    {
        score += 1;
        freeLifeCounter += 1;
    }

    private void LoseLife()
    {
        lives -= 1;
    }

    //No touchie-----------------------------------------------------------v

    private void KeepGameManager() //Keeps the GameManager across scenes.
    {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    static MinigameList GetRandomGame<MinigameList>() //Picks a random minigame.
    {
        Array array = Enum.GetValues(typeof(MinigameList));
        MinigameList value = (MinigameList)array.GetValue(UnityEngine.Random.Range(0, array.Length));
        return value;
    }
}