using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_ArrowRotation : MonoBehaviour
{
    //Makes the arrow move back and forth.

    public GameObject arrow;
    public float rotationAngle;
    private float arrowSpeed = 50f;
    private bool reverse;

    private void Start()
    {
        reverse = false;
    }

    void Update()
    {
        if (rotationAngle >= 30.0f)
            reverse = true;

        if (rotationAngle <= -30.0f)
            reverse = false;

        if (reverse == false)
            rotationAngle += Time.deltaTime * arrowSpeed;

        if (reverse == true)
            rotationAngle -= Time.deltaTime * arrowSpeed;

        arrow.transform.rotation = Quaternion.Euler(new Vector3(0, rotationAngle, 0));
    }
}