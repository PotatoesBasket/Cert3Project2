using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_GunMovement : MonoBehaviour
{
    //Moves gun. Badly written but it works I guess.

    private Zombie_Manager manager;

    private Vector3 mouse;
    private Vector3 smooth;

    public float sensitivity;
    public float smoothing;

    public float minRotationX;
    public float maxRotationX;
    public float minRotationY;
    public float maxRotationY;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Zombie_Manager>();
    }

    private void Update()
    {
        if (manager.canMove == true)
        {
            MovementCalculation();
            Rotation();
        }
    }

    private Vector3 MovementCalculation() //Takes mouse input and adjusts according to smoothing and sensitivity values.
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smooth.x = Mathf.Lerp(smooth.x, mouseDelta.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouseDelta.y, 1f / smoothing);
        mouse += smooth;

        return mouse;
    }

    private void Rotation() //Limits rotation and applies it. Set min/max to -Infinity/Infinity to turn limits off.
    {
        mouse.x = Mathf.Clamp(mouse.x, minRotationX, maxRotationX);
        mouse.y = Mathf.Clamp(mouse.y, minRotationY, maxRotationY);

        transform.rotation = Quaternion.Euler(0, mouse.x + 90, -mouse.y / 4);
    }
}