using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public HighScores highScores;

    public float gameSpeed;
    public float gameTimer;
    public float gameTimeLimit;
    public string command;
    public int lives;
    public int score;
    public int freeLifeCounter;

    public bool playNewMGAni = false;
    public bool completedGoal = false;
    public bool minigameOver = false;
    public bool gameOver = false;
    public bool isPaused = false;
    public bool showPausePanel = false;
    public bool playCoverFade = false;
    public bool playFreeLife = false;
    public bool musicOn = true;

    public enum GameState
    {
        TitleScreen,
        Game,
        GameOver,
        Pause
    }
    public GameState gameState;

    public enum MinigameList
    {
        Golf,
        Car,
        Catch,
        Pong,
        Ship
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
        nextGame = GetRandomGame<MinigameList>();
        NewGameValues();
    }

    private void Update()
    {
        GameTimer();
        GameOver();
        Pause();
        Sound();
    }


    //---------------------------------------------------------------------v

    public void NewGameValues()
    {
        gameTimeLimit = 5f;
        gameSpeed = 0.98f;
        lives = 4;
        score = 1;
        freeLifeCounter = 1;
        NewMinigameValues();
    }

    private void NewMinigameValues()
    {
        gameTimer = 0f;
        gameSpeed += 0.01f;
        playNewMGAni = true;
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

        currentGame = nextGame;
        SceneManager.LoadScene(nextGame.ToString());

        do { nextGame = GetRandomGame<MinigameList>(); }
        while (nextGame == currentGame || nextGame == prevGame);
    }

    private void AddToScore()
    {
        score += 1;
        freeLifeCounter += 1;

        if (freeLifeCounter == 25)
        {
            if (lives < 4 && lives > 0)
                lives += 1;
            freeLifeCounter = 1;
            playFreeLife = true;
        }
    }

    private void LoseLife()
    {
        lives -= 1;
    }

    private void GameOver()
    {
        if (lives <= 0 && gameState == GameState.Game)
        {
            score--;

#if UNITY_STANDALONE || UNITY_EDITOR
            highScores.AddScore(score);
            highScores.SaveScoresToFile();
            SceneManager.LoadScene("Game Over");
#endif

#if UNITY_WEBGL
            SceneManager.LoadScene("Game Over Web");
#endif

            gameState = GameState.GameOver;
            Destroy(GameObject.FindWithTag("HUD"));

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Pause()
    {
        if (Input.GetButtonDown("Fire2") && isPaused == false && gameState == GameState.Game)
        {
            isPaused = true;
            showPausePanel = true;
            Time.timeScale = 0;
            AudioListener.pause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameState = GameState.Pause;
        }
    }

    private void Sound()
    {
        if (musicOn == true)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;
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
}