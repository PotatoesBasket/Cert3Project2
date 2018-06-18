using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Movement : MonoBehaviour
{
    private Catch_Manager manager;
    private Rigidbody plate;
    public Vector3 move;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Catch_Manager>();
    }

    private void Start()
    {
        plate = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (manager.on == true)
        {
            move = new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y"));
            plate.MovePosition(plate.position + move);
        }
    }
}