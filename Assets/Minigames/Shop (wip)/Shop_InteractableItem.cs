using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_InteractableItem : MonoBehaviour
{
    //Attatched to items that can be picked up in Shop minigame.

    //Used in Shop_ItemInteraction
    public bool isGrabbed = false;
    public bool isHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isGrabbed == true)
            isHit = true;
    }
}