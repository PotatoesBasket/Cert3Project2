using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameManager gameManager;

    public void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    public void StartButton()
    {
        gameManager.gameState = GameManager.GameState.Game;
        gameManager.SwitchGame();
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }

    public void SettingsButton()
    {
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}