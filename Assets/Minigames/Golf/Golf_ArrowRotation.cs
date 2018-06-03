using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_ArrowRotation : MonoBehaviour
{
    //Makes the arrow move back and forth.

    public Golf_Manager manager;
    public GameObject arrow;
    public float rotationAngle;
    private float arrowSpeed = 50f;
    private bool reverse = false;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Golf_Manager>();
    }

    void Update()
    {
        if (manager.on == true)
        {
            if (rotationAngle >= 30.0f)
                reverse = true;

            if (rotationAngle <= -30.0f)
                reverse = false;

            if (reverse == false)
                rotationAngle += Time.deltaTime * arrowSpeed * manager.GameSpeed;

            if (reverse == true)
                rotationAngle -= Time.deltaTime * arrowSpeed * manager.GameSpeed;

            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, rotationAngle, 0));
        }
    }
}