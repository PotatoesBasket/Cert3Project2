using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_Spawn : MonoBehaviour
{
    public GameObject redBall;
    public GameObject greenBall;
    private bool spawnRed;

    private void Awake()
    {
        spawnRed = (Random.value > 0.5f);
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn() //Spawns ball based on spawnRed value.
    {
        if (spawnRed == true)
            redBall.SetActive(true);

        if (spawnRed == false)
            greenBall.SetActive(true);
    }
}