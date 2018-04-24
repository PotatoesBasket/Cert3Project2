using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetection : MonoBehaviour
{
    //Contains debug tools. Remove before release.

    //Handles detection of and interaction with items in the game world.

    RaycastHit hit;
    GameObject player = null;
    GameObject hand = null;
    public GameObject itemInRange = null;
    public GameObject itemInHand = null;
    private float rayDistance = 15;
    private int layerMask = 1 << 0;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            hand = GameObject.FindGameObjectWithTag("ItemInHand");
        }
    }

    private void Update()
    {
        ItemDetection();
        ItemInteraction();
        MovingItem();
        DebugTools();
    }

    private void ItemDetection() //Sets itemInRange to object currently being hit by ray.
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, layerMask) && hit.rigidbody != null)
            itemInRange = hit.rigidbody.gameObject;
        else
            itemInRange = null;
    }

    private void ItemInteraction()
    {
        if (itemInRange != null && itemInRange.tag == "Item_ObtainOnClick" && Input.GetButtonDown("Fire1"))
        {
            itemInRange.SetActive(false);
            itemInRange = null;
        }

        if (itemInRange != null && itemInRange.tag == "Item_Moveable" && Input.GetButtonDown("Fire1"))
        {
            itemInHand = itemInRange;
        }
    }

    private void MovingItem()
    {
        if (itemInHand != null)
        {
            itemInHand.transform.SetParent(hand.transform);
            //itemInHand.GetComponentInChildren<Rigidbody>().isKinematic = true;
            itemInHand.GetComponentInChildren<Rigidbody>().useGravity = false;
            itemInHand.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void DebugTools()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, layerMask))
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        else
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.white);
    }
}