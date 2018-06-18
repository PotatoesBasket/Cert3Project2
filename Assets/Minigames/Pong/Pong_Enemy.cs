using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Enemy : MonoBehaviour
{
    private Pong_Manager manager;
    public GameObject ball;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Pong_Manager>();
    }

    private void Update()
    {
        if (manager.on == true)
            transform.position = new Vector3(transform.position.x, ball.transform.position.y / 1.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        manager.paddle.Play();
    }
}