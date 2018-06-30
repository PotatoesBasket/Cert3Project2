using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_AutoDrive : MonoBehaviour
{
    //Moves rigidbody forward automatically and allows for turning with the mouse's horizontal axis.
    //Car forward speed affected by overall game speed.

    private Car_Manager manager;
    private Rigidbody car;

    public float speed = 20.0f;
    public float turnSpeed = 100.0f;
    private float turnInput;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Car_Manager>();
        car = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (manager.on == true)
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
#if UNITY_STANDALONE || UNITY_EDITOR
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn / 2, 0f);
        car.MoveRotation(car.rotation * turnRotation);
#endif

#if UNITY_WEBGL
        float turnW = turnInput / 2 * turnSpeed * Time.deltaTime;
        Quaternion turnRotationW = Quaternion.Euler(0f, turnW / 2, 0f);
        car.MoveRotation(car.rotation * turnRotationW);
#endif
    }
}