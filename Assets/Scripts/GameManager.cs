using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Contains debug tools. Remove before release.
    //Contains TO DOs.

    public static GameManager gameManager;

    public float timeLimit;
    public float gameTimer;
    public float gameSpeed;
    public int lives;
    public int score;
    public int freeLifeCounter;
    public string command;

    public bool playCommandAni = false;
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

    private void Start()
    {
        timeLimit = 5f;
        gameTimer = 0f;
        gameSpeed = 1.0f;
        lives = 3;
        score = 0;
        freeLifeCounter = 0;
    }

    private void Update()
    {
        FreeLife();
        OnGameFinish();
        GameTimer();
        DebugTools();

        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }


    //-----Call Elsewhere-----//

    public void SwitchGame() //Loads queued minigame and determines the one to play next without picking a recent one.
    {
        playCommandAni = true;
        gameOver = false;
        gameTimer = 0f;
        gameSpeed += 0.02f;
        prevGame = currentGame;

        bool generateNextGame;
        generateNextGame = false;

        if (generateNextGame == false)
        {
            currentGame = nextGame;
            SceneManager.LoadScene(gameToBeLoaded);
            generateNextGame = true;
        }

        if (generateNextGame == true) //TO DO: make better.
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

    public void AddToScore() //Adds 1 to score and free life counter.
    {
        score += 1;
        freeLifeCounter += 1;
    }

    public void LoseLife() //Minus 1 life.
    {
        lives -= 1;
    }


    //-----Call in Update()-----//

    public void FreeLife() //Adds a life after 25 wins.
    {
        if (freeLifeCounter == 25)
        {
            lives += 1;
            freeLifeCounter = 0;
        }
    }

    public void GameTimer() //Keeps a timer that determines how long each game lasts. Speeds up as the game progresses.
    {
        gameTimer += gameSpeed * Time.deltaTime;

        if (gameTimer >= timeLimit)
            gameOver = true;
    }

    public void OnGameFinish() //Adds to score/minus life depending on completedGoal bool when game ends.
    {
        if (gameOver == true)
        {
            if (completedGoal == true)
                AddToScore();
            if (completedGoal == false)
                LoseLife();

            //SwitchGame();
        }
        //TO DO: if lives = 0, end game.
    }


    //-----Don't worry about these rn-----//

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
        if (Input.GetKeyDown("q"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown("p"))
            SwitchGame();

        if (Input.GetKeyDown("o"))
            AddToScore();

        if (Input.GetKeyDown("i"))
            LoseLife();
    }
}