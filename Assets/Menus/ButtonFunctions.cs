using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameManager gameManager;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void StartButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.playCoverFade = true;
        Invoke("StartButtonDelayed", 1f);
    }

    private void StartButtonDelayed()
    {
        gameManager.NewGameValues();
        gameManager.SwitchGame();
        gameManager.gameState = GameManager.GameState.Game;
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}