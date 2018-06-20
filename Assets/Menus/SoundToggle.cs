using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject musicOn;
    public GameObject musicOff;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        if (gameManager.musicOn == true)
            musicOn.SetActive(true);
        else
            musicOff.SetActive(true);
    }

    public void OnMusicToggle()
    {
        if (gameManager.musicOn == true)
        {
            gameManager.musicOn = false;
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else
        {
            gameManager.musicOn = true;
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }
}