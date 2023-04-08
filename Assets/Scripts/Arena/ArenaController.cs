using System;
using System.Collections;
using Arena;
using GameControl;
using MalbersAnimations;
using MalbersAnimations.Controller;
using MalbersAnimations.Events;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ArenaController : MonoBehaviour
{
    private Zone _zone;
    private AnimalSpawnerFromZone _animalSpawnerFromZone;
    [SerializeField] private float delay = 5f;
    [SerializeField] private const int MaxAnimalsToSpawn = 15;
    [SerializeField] private int animalsSpawned = 0;

    [SerializeField] private GameObject questionParticleSystem;
    [SerializeField] private AudioSource enableSound;
    [SerializeField] private TextMeshProUGUI animalsLeftText;
    [SerializeField] private GameController gameController;

    [SerializeField] private GameObject elkCanvas;
    [SerializeField] private Collider starCollider;
    [SerializeField] private GameObject gameSound;
    [SerializeField] private AudioSource spawnSound;
    [SerializeField] private UnityEventRaiser eventRaiser;

    [SerializeField] private UnityUtils unityUtils;
    [SerializeField] private TextMeshProUGUI textTime = null;
    [SerializeField] private int timeInSeconds = 0;

    private void Awake()
    {
        _zone = GetComponent<Zone>();
        unityUtils = GetComponentInChildren<UnityUtils>();
        _animalSpawnerFromZone = GetComponentInChildren<AnimalSpawnerFromZone>();
    }

    private void Start()
    {
        elkCanvas.SetActive(false);
    }

    public void DisableAndEnableZoneAfterDelay()
    {
        StartCoroutine(DisableAndEnableZone());
    }

    private IEnumerator Time()
    {
        while (true)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
        }
    }

    private void TimeCount()
    {
        timeInSeconds += 1;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        string timeText = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        textTime.SetText(timeText);
    }

    private IEnumerator DisableAndEnableZone()
    {
        if (animalsSpawned < MaxAnimalsToSpawn)
        {
            _animalSpawnerFromZone.InstantiateAndActivateAnimal(1);
            animalsSpawned++;

            int animalsLeft = MaxAnimalsToSpawn - animalsSpawned;
            animalsLeftText.text = animalsLeft.ToString();


            questionParticleSystem.SetActive(false);
            _zone.enabled = false;
        }
        else
        {
            _zone.enabled = false;
        }

        yield return new WaitForSecondsRealtime(delay);

        if (animalsSpawned <= MaxAnimalsToSpawn)
        {
            enableSound.Play();
            questionParticleSystem.SetActive(true);
            _zone.enabled = true;
        }
        else
        {
            gameController.LoadGameOverCanvas();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<PlayerManager>();

        if (player != null)
        {
            unityUtils.Time_Freeze(true);
            elkCanvas.SetActive(true);
        }
    }

    public void StartMission(bool startMission)
    {
        unityUtils.Time_Freeze(false);
        elkCanvas.SetActive(false);
        SetBoxColliderEnabled(false);
        gameSound.SetActive(true);
        spawnSound.Play();
        eventRaiser.OnEnable();
        StartCoroutine(Time());
    }

    public void SetBoxColliderEnabled(bool enableCollider)
    {
        starCollider.enabled = enableCollider;
    }
}