using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public Transform panel;
    public Transform target;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float animDuration;
    private bool areSettingsOpen = false;

    private void Start()
    {
        startPos = panel.position;
        targetPos = new Vector3(target.position.x, startPos.y);
        animDuration = 0.3f;
    }

    public void OnSettingsButton()
    {
        if (areSettingsOpen == false)
        {
            StartCoroutine(SettingsPanelAnimate(startPos, targetPos, animDuration));
            areSettingsOpen = true;
        }
        else
        {
            StartCoroutine(SettingsPanelAnimate(targetPos, startPos, animDuration));
            areSettingsOpen = false;
        }
    }

    private IEnumerator SettingsPanelAnimate(Vector3 origin, Vector3 target, float duration)
    {
        float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            panel.position = Vector3.Lerp(origin, target, percent);

            yield return null;
        }
    }
}