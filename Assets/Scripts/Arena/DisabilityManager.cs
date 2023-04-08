using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations;
using MalbersAnimations.Controller;
using UnityEngine;

public class DisabilityManager : MonoBehaviour
{
    [SerializeField] private Zone zoneToDisable;
    [SerializeField] private float disableTime = 5f;
    [SerializeField] private GameObject showOnDisabled;
    [SerializeField] private Stats stats;

    public void DisableGameObjects()
    {
        StartCoroutine(DisableAndEnableGameObjects());
    }   
    public void DisableAndEnableBaseObject()
    {
        StartCoroutine(DisableAndEnableSelf());
    }

    private IEnumerator DisableAndEnableGameObjects()
    {
        zoneToDisable.enabled = false; 
        showOnDisabled.SetActive(true);

        yield return new WaitForSecondsRealtime(disableTime);

        zoneToDisable.enabled = true; 
        showOnDisabled.SetActive(false);
    }
    private IEnumerator DisableAndEnableSelf()
    {
        gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(disableTime);
        stats.Restart();
        gameObject.SetActive(true);
    }
}