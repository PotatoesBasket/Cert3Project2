using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Contains debug tools. Remove before release.

    public static GameManager gameManager;

    public float timeLimit = 8f;
    public float gameTimer = 0f;
    public float gameSpeed = 1f;
    public int lives = 3;
    public int score = 0;
    public string command;

    public bool completedGoal = false;
    public bool gameOver = false;
    public string gameToBeLoaded;

    public enum GameState
    {
        TitleScreen,
        Game,
        Pause,
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
        nextGame = GetRandomGame<MinigameList>();
        currentGame = nextGame;
        gameToBeLoaded = nextGame.ToString();
    }

    private void Update()
    {
        GameTimer();
        DebugTools();
    }

    public void SwitchGame() //Loads queued minigame and determines the one to play next without picking a recent one.
    {
        bool generateNextGame;

        prevGame = currentGame;
        generateNextGame = false;

        if (generateNextGame == false)
        {
            currentGame = nextGame;
            SceneManager.LoadScene(gameToBeLoaded);
            generateNextGame = true;
        }

        if (generateNextGame == true)
        {
            nextGame = GetRandomGame<MinigameList>();
            if (nextGame == prevGame)
                nextGame += 1;
            if (nextGame >= (MinigameList)5)
                nextGame = 0;
            if (nextGame == currentGame)
                nextGame += 1;
            if (nextGame >= (MinigameList)5)
                nextGame = 0;
            gameToBeLoaded = nextGame.ToString();
        }
    }

    public void GameOver()
    {
        if (gameOver == true)
        {
            gameTimer = 0f;
        }
    }

    public void GameTimer()
    {
        if (gameTimer < timeLimit)
            gameTimer += Time.deltaTime;
        
        if (gameTimer == timeLimit)
            gameTimer = 0f;
    }

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

    private void DebugTools()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown("p"))
        {
            SwitchGame();
        }
    }
}