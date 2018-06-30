using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;
    public Text[] scores;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        if (gameManager.highScores != null)
        {
            for (int i = 0; i < gameManager.highScores.scores.Length; i++)
            {
                int score = gameManager.highScores.scores[i];
                string text = (i + 1) + ". " + score;
                scores[i].text = text;
            }
        }
        ShowPlayerScore();
    }

    private void ShowPlayerScore()
    {
        if (gameManager.highScores != null)
        {
            for (int i = 0; i < gameManager.highScores.scores.Length; i++)
            {
                if (gameManager.highScores.scores[i] == gameManager.score)
                {
                    scores[i].color = Color.red;
                    break;
                }
            }
        }
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("Title Screen");
        gameManager.gameState = GameManager.GameState.TitleScreen;
        gameManager.NewGameValues();
    }
}