using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Movement : MonoBehaviour
{
    private Catch_Manager manager;
    private Rigidbody plate;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MiniManager").GetComponent<Catch_Manager>();
    }

    private void Start()
    {
        plate = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (manager.on == true)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            Vector3 move = new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y"));
            plate.MovePosition(plate.position + move);
#endif

#if UNITY_WEBGL
            Vector3 moveW = new Vector3(Input.GetAxisRaw("Mouse X") / 2, 0, Input.GetAxisRaw("Mouse Y") / 2);
            plate.MovePosition(plate.position + moveW);
#endif
        }
    }
}