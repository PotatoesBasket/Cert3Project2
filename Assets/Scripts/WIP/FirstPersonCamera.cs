using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    //Controls the camera with the mouse. Affects the parent's x-axis.

    private GameObject cameraParent;
    private Vector3 mouse;
    private Vector3 smooth;

    public float sensitivity;
    public float smoothing;

    public float minRotationX;
    public float maxRotationX;
    public float minRotationY;
    public float maxRotationY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraParent = this.transform.parent.gameObject;
    }

    private void Update()
    {
        MovementCalculation();
        RotationLimits();
        CameraRotation();
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

    private void RotationLimits() //Applies limits to mouse value. Set min/max to -Infinity/Infinity to turn off.
    {
        mouse.x = Mathf.Clamp(mouse.x, minRotationX, maxRotationX);
        mouse.y = Mathf.Clamp(mouse.y, minRotationY, maxRotationY);
    }

    private void CameraRotation() //Rotates camera's x axis and parent's y axis.
    {
        transform.localRotation = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        cameraParent.transform.rotation = Quaternion.AngleAxis(mouse.x, cameraParent.transform.up);
    }
}