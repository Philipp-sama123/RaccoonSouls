using System.Collections;
using Arena;
using GameControl;
using MalbersAnimations.Controller;
using TMPro;
using UnityEngine;

public class ElkController : MonoBehaviour
{
    private Zone _zone;
    private TriggerElk _triggerElk;
    private AnimalSpawnerFromZone _animalSpawnerFromZone;
    [SerializeField] private float delay = 5f;
    [SerializeField] private const int MaxAnimalsToSpawn = 15;
    [SerializeField] private int animalsSpawned = 0;

    [SerializeField] private GameObject questionParticleSystem;
    [SerializeField] private AudioSource enableSound;
    [SerializeField] private TextMeshProUGUI animalsLeftText;
    [SerializeField] private SurvivalController survivalController;

    private void Awake()
    {
        _zone = GetComponent<Zone>();
        _triggerElk = GetComponentInChildren<TriggerElk>();
        _animalSpawnerFromZone = GetComponentInChildren<AnimalSpawnerFromZone>();
        survivalController = GetComponentInChildren<SurvivalController>();
    }

    public void DisableAndEnableZoneAfterDelay()
    {
        StartCoroutine(DisableAndEnableZone());
    }

    private IEnumerator DisableAndEnableZone()
    {
        if (animalsSpawned < MaxAnimalsToSpawn)
        {
            _animalSpawnerFromZone.InstantiateAndActivateAnimal(1);
            animalsSpawned++;

            int animalsLeft = MaxAnimalsToSpawn - animalsSpawned;
            animalsLeftText.text = animalsLeft.ToString();

            _triggerElk.DisableElkTrigger();

            questionParticleSystem.SetActive(false);
            _zone.enabled = false;
        }
        else
        {
            _triggerElk.DestroyElkTrigger();
            _zone.enabled = false;
        }

        yield return new WaitForSecondsRealtime(delay);
        
        if (animalsSpawned <= MaxAnimalsToSpawn)
        {
            enableSound.Play();
            questionParticleSystem.SetActive(true);
            _zone.enabled = true;
            _triggerElk.EnableElkTrigger();
        }
        else
        {
            survivalController.LoadGameOverCanvas();
        }
    }
}