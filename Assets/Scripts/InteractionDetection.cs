using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetection : MonoBehaviour {

    //Handles detection of and interaction with items in the game world.
    //Contains debug tools. Remove before release.

    RaycastHit hit;
    GameObject player = null;
    GameObject item = null;
    public float rayDistance = 15;
    private int layerMask = 1 << 0;

    private void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        ItemDetection();
        ItemInteraction();
        IsItemInReach();
        DebugTool();
    }

    private void ItemDetection()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, layerMask) && hit.rigidbody != null)
        {
            item = hit.rigidbody.gameObject;
        }
        else
        {
            item = null;
        }
    }

    private void ItemInteraction()
    {
        if (item != null && item.tag == "Item_ObtainOnClick" && Input.GetButtonDown("Fire1"))
        {
            item.SetActive(false);
            item = null;
        }

        //WIP
        if (item != null && item.tag == "Item_Moveable" && Input.GetButtonDown("Fire1"))
        {
            Rigidbody rigid = item.GetComponent<Rigidbody>();
            rigid.isKinematic = true;
        }
    }

    public bool IsItemInReach()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, layerMask))
            return true;
        else
            return false;
    }

    //DEBUG

    private void DebugTool()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}
