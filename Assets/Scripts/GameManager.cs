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
    public float gameSpeed = 1f;
    public int lives = 3;
    public int score = 0;
    public string command;

    public bool completedGoal = false;
    public bool gameOver = false;
    public bool newGame = true;
    public bool switchGame = false;
    public string gameToBeLoaded;

    public enum GameState
    {
        TitleScreen,
        Game,
        Pause,
        HUD
    }

    public GameState gameState;

    public enum MinigameList
    {
        Golf,
        Car,
        Catch
    }

    public MinigameList prevGame;
    public MinigameList currentGame;
    public MinigameList nextGame;

    private void Awake()
    {
        KeepGameManager();
        nextGame = GetRandomGame<MinigameList>();
        gameToBeLoaded = nextGame.ToString();
    }

    private void Update()
    {
        GameSwitch();
        DebugTools();
    }

    private void KeepGameManager() //Keeps the GameManager across scenes.
    {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void GameSwitch() //Handles switching of minigames.
    {
        if (newGame == true)
        {
            prevGame = currentGame;
            switchGame = true;

            if (switchGame == true)
            {
                nextGame = GetRandomGame<MinigameList>();
                if (nextGame == currentGame)
                    nextGame += 1;
                switchGame = false;
            }

            if (switchGame == false)
            {
                currentGame = nextGame;
                gameToBeLoaded = nextGame.ToString();
            }

            newGame = false;
        }
    }

    public void GameTimer()
    {

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
    }
}