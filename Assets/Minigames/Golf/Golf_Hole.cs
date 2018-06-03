using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Hole : MonoBehaviour
{
    //Turns off the floor's collider so it looks like the ball is falling in the hole. Activates win state.

    private Golf_Manager manager;
    public GameObject floor;

    private void Start()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Golf_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        floor.GetComponent<Collider>().enabled = false;
        manager.gameManager.completedGoal = true;
        manager.goal.Play();
        manager.clap.Play();
    }
}