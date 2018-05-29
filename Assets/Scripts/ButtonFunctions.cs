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
        gameManager.NewGameValues();
        gameManager.SwitchGame();
        gameManager.gameState = GameManager.GameState.Game;
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SettingsButton()
    {
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}