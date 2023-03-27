using System;
using System.Collections;
using MalbersAnimations.Controller;
using UnityEngine;

public class RaccoonZoneController : MonoBehaviour
{
    private Zone _zone;
    private TriggerRaccoon _triggerRaccoon;
    [SerializeField] private float delay = 5f;
    [SerializeField] private GameObject questionParticleSystem;
    [SerializeField] private AudioSource enableSound;
    [SerializeField] private GameObject healthObject;
    [SerializeField] private Transform spawnTransform;
    private void Awake()
    {
        _zone = GetComponent<Zone>();
        _triggerRaccoon = GetComponentInChildren<TriggerRaccoon>();
    }
    
    public void DisableAndEnableZoneAfterDelay()
    {
        StartCoroutine(DisableAndEnableZone());
    }

    public void InstantiateHealthObject()
    {
        var instantiated = Instantiate(healthObject, spawnTransform);
        instantiated.transform.parent = null;
    }

    private IEnumerator DisableAndEnableZone()
    {
        _zone.enabled = false;
        questionParticleSystem.SetActive(false);

        yield return new WaitForSecondsRealtime(delay);

        enableSound.Play();
        questionParticleSystem.SetActive(true);
        _zone.enabled = true;
        _triggerRaccoon.EnableRaccoonTrigger();
    }
}