using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //Turns off the floor's collider so it looks like the ball is falling in the hole. Activates win state.

    //WIP - No clue if the GameManager stuff actually works.

    private GameManager gameManager;
    public GameObject floor;

    private void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        floor.GetComponent<Collider>().enabled = false;
        gameManager.completedGoal = true;
    }
}