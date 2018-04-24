using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Contains debug tools. Remove before release.

    public static GameManager gameManager;

    public float timeLimit;
    public float gameSpeed;
    public int lives = 3;
    public bool completedGoal = false;
    public bool switchGame = false;
    public string gameToBeLoaded;

    public enum GameState
    {
        TitleScreen,
        Game,
        Pause,
        Transition
    }

    public GameState gameState;

    public enum MinigameList
    {
        Golf,
        Car,
        Butt,
        Butt2
    }

    public MinigameList prevGame;
    public MinigameList currentGame;
    public MinigameList nextGame;

    private void Awake()
    {
        KeepGameManager();

        if (gameState != GameState.TitleScreen)
            gameState = GameState.TitleScreen;

        nextGame = GetRandomEnum<MinigameList>();
    }

    private void Update()
    {
        StateSwitch();
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

    private void StateSwitch() //Handles switching of game states.
    {
        switch (gameState)
        {
            case GameState.TitleScreen:
                SceneManager.LoadScene("Title Screen");
                break;

            case GameState.Game:
                SceneManager.LoadScene(gameToBeLoaded);
                break;

            case GameState.Transition:
                SceneManager.LoadScene("Transition", LoadSceneMode.Additive);
                break;

            case GameState.Pause:
                SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
                break;
        }
    }

    private void GameSwitch() //Handles switching of minigames.
    {
        if (gameState == GameState.Game)
        {
            prevGame = currentGame;
            switchGame = true;

            if (switchGame == true)
            {
                nextGame = GetRandomEnum<MinigameList>();
                switchGame = false;
            }

            if (nextGame == currentGame)
                nextGame += 1;
        }
        if (gameState == GameState.Transition)
        {
            currentGame = nextGame;
            gameToBeLoaded = nextGame.ToString();
        }

        switch (currentGame)
        {
            case MinigameList.Golf:
                break;
        }
    }

    static MinigameList GetRandomEnum<MinigameList>() //Picks a random minigame.
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