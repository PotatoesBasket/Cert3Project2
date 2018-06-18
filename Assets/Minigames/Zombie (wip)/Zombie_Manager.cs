using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Manager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] zombies;
    public bool canMove;
    public bool isHit;
    public float GameSpeed { get { return gameManager.gameSpeed; } }

    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.command = "Shoot 'em!";
        gameManager.completedGoal = false;
        gameManager.minigameOver = false;
        canMove = true;
    }

    private void Update()
    {
        if (AllZombiesDead() == true)
        {
            gameManager.completedGoal = true;
        }
    }

    private void SpawnEnemies()
    {

    }

    private bool AllZombiesDead()
    {
        int numberOfZombies = 0;

        foreach (GameObject zombie in zombies)
        {
            if (isHit == false)
                numberOfZombies++;
        }

        return (numberOfZombies == 0);
    }
}