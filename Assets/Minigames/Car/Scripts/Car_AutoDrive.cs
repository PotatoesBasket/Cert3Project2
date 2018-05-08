using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_AutoDrive : MonoBehaviour
{
    //Moves rigidbody forward automatically and allows for turning with the mouse's horizontal axis.
    //Car forward speed affected by overall game speed.

    //WIP - No mouse controls yet. Turn with A and D.

    private Car_Manager manager;
    public Rigidbody car;

    public float speed = 20.0f;
    public float turnSpeed = 100.0f;
    private float turnInput;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Car_Manager>();
    }

    void Update()
    {
        turnInput = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        if (manager.on == true)
        {
            Move();
            Turn();
        }

        if (manager.on == false)
        {
            car.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void Move()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime * manager.GameSpeed;
        car.MovePosition(car.position + movement);
    }

    private void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        car.MoveRotation(car.rotation * turnRotation);
    }
}