using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_FailTrigger : MonoBehaviour
{
    private Pong_Manager manager;
    public Collider ball;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Pong_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
            manager.gameManager.completedGoal = false;
    }
}