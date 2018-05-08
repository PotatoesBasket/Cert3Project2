using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Enemy : MonoBehaviour
{
    //This code is bad because it won't work properly if I change the size of the level or paddle.
    //It's good though because it's tiny and actually works lol.

    private Rigidbody enemy;
    public Rigidbody ball;
    public Vector3 movement;

    private void Start()
    {
        enemy = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        enemy.transform.position = new Vector3(enemy.position.x, ball.position.y / 1.2f);
    }
}