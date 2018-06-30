using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWeb : MonoBehaviour
{
    public GameManager gameManager;
    public Text webScore;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        webScore.text = gameManager.score.ToString();
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("Title Screen");
        gameManager.gameState = GameManager.GameState.TitleScreen;
        gameManager.NewGameValues();
    }
}