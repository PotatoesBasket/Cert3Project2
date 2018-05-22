using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_Pivot : MonoBehaviour
{
    private Rigidbody pivot;
    private float turnInput;
    public float turnSpeed;

    private void Start()
    {
        pivot = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        turnInput = Input.GetAxis("Mouse X");

        float turn = -turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
        pivot.MoveRotation(pivot.rotation * turnRotation);
    }
}