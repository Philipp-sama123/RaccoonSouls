using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Controller;
using UnityEngine;

public class DisabilityManager : MonoBehaviour
{
    [SerializeField] private Zone zoneToDisable;
    [SerializeField] private float disableTime = 5f;
    [SerializeField] private GameObject showOnDisabled;

    public void DisableGameObjects()
    {
        StartCoroutine(DisableAndEnableGameObjects());
    }

    private IEnumerator DisableAndEnableGameObjects()
    {
        zoneToDisable.enabled = false; 
        showOnDisabled.SetActive(true);

        yield return new WaitForSecondsRealtime(disableTime);

        zoneToDisable.enabled = true; 
        showOnDisabled.SetActive(false);
    }
}