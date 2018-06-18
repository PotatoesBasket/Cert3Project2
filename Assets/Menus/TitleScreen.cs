using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject deer;
    private float radius = 15f;
    private float speed = 0.2f;
    private bool offsetIsCenter = true;
    private Vector3 offset;

    public Animation coverFadeOut;
    public Animation coverFadeIn;
    public GameObject settingsPanel;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        coverFadeOut.Play();

        if (offsetIsCenter)
            offset = transform.position;
    }

    private void Update()
    {
        RotateCamera();
        ActivateCoverFade();
    }

    private void RotateCamera()
    {
        transform.position = new Vector3(
            (radius * Mathf.Cos(Time.time * speed)) + offset.x,
            offset.y,
            (radius * Mathf.Sin(Time.time * speed)) + offset.z);
        transform.LookAt(deer.transform);
    }

    private void ActivateCoverFade()
    {
        if (gameManager.playCoverFade == true)
        {
            coverFadeIn.Play();
            gameManager.playCoverFade = false;
        }
    }
}