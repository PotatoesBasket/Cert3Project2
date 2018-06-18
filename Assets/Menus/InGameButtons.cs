using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtons : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject exitConfirmPanel;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void ContinueButton()
    {
        gameManager.isPaused = false;
        gameManager.showPausePanel = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.gameState = GameManager.GameState.Game;
    }

    public void SettingsButton()
    {
        gameManager.showPausePanel = false;
        settingsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        gameManager.showPausePanel = false;
        exitConfirmPanel.SetActive(true);
    }

    public void SoundOn()
    {
        gameManager.musicOn = true;
        settingsPanel.SetActive(false);
        gameManager.showPausePanel = true;
    }

    public void SoundOff()
    {
        gameManager.musicOn = false;
        settingsPanel.SetActive(false);
        gameManager.showPausePanel = true;
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        exitConfirmPanel.SetActive(false);
        gameManager.showPausePanel = true;
    }
}