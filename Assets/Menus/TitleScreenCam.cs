using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCam : MonoBehaviour
{
    public GameObject deer;
    private float radius = 15f;
    private float speed = 0.2f;
    private bool offsetIsCenter = true;
    private Vector3 offset;

    private void Start()
    {
        if (offsetIsCenter)
            offset = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(
            (radius * Mathf.Cos(Time.time * speed)) + offset.x,
            offset.y,
            (radius * Mathf.Sin(Time.time * speed)) + offset.z);
        transform.LookAt(deer.transform);
    }
}