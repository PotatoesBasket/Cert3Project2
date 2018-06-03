using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverAni : MonoBehaviour
{
    private Animation coverAni;
    private float timer;

    private void Start()
    {
        coverAni = GetComponent<Animation>();
        coverAni.Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= coverAni["CoverFadeOut"].length)
            gameObject.SetActive(false);
    }
}