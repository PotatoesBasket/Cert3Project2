using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Ball : MonoBehaviour
{
    //Shoots ball in the same direction as the arrow (Golf_ArrowRotation).

    public Golf_Manager manager;
    public Golf_ArrowRotation rotation;
    public GameObject ball;
    public GameObject arrow;

    void Start()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Golf_Manager>();
        rotation = arrow.GetComponent<Golf_ArrowRotation>();
    }

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Fire1") && manager.on == true)
        {
            rb.AddForce(rotation.rotationAngle * 2, 0, 250);
            manager.on = false;
            manager.putt.Play();
            manager.hasShot = true;
        }
    }
}