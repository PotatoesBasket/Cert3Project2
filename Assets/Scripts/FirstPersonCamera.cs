using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

    //Controls the main game camera with the mouse.

    private GameObject player;
    private Vector3 mouse;
    private Vector3 smooth;
    public float sensitivity = 2f;
    public float smoothing = 3f;
    private float minRotation = -75f;
    private float maxRotation = 75f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = this.transform.parent.gameObject;
    }

    private void Update()
    {
        MouseMovement();
    }

    private void MouseMovement()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smooth.x = Mathf.Lerp(smooth.x, mouseDelta.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouseDelta.y, 1f / smoothing);

        mouse += smooth;
        mouse.y = Mathf.Clamp(mouse.y, minRotation, maxRotation);

        transform.localRotation = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouse.x, player.transform.up);
    }
}
