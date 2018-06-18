using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_ItemInteraction : MonoBehaviour
{
    private Shop_InteractableItem item = null;
    private Rigidbody itemInRange = null;
    private Rigidbody itemInHand = null;
    private RaycastHit hit;
    private float rayDistance = 10;

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance) && hit.rigidbody != null)
            itemInRange = hit.rigidbody;
        else
            itemInRange = null;

        if (item != null) //Drops item if it hits something.
        {
            if (item.isHit == true)
                Drop();
        }

        if (itemInRange != null && itemInHand == null && Input.GetButtonDown("Fire1"))
            Grab();

        if (itemInHand != null && Input.GetButtonUp("Fire1"))
            Drop();

        Drag();
    }

    private void Grab()
    {
        itemInHand = itemInRange;
        itemInHand.transform.SetParent(transform);
        itemInHand.useGravity = false;

        item = itemInHand.GetComponent<Shop_InteractableItem>();
        item.isGrabbed = true;
    }

    private void Drag()
    {
        if (item != null)
        {
            if (item.isGrabbed == true)
            {
            }
        }
    }

    private void Drop()
    {
        item.isGrabbed = false;
        item.isHit = false;
        item = null;

        itemInHand.useGravity = true;
        itemInHand = null;

        transform.DetachChildren();
    }
}