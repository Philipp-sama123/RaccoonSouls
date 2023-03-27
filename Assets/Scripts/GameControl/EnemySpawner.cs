using System.Collections;
using MalbersAnimations.Controller.AI;
using UnityEngine;

namespace GameControl
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject bossAnimalToSpawn;
        [SerializeField] private GameObject ultimateBossAnimalToSpawn;

        [SerializeField] private GameObject startWaypoint;
        [SerializeField] private Transform spawnPosition;

        [SerializeField] private float spawnDelay = 30f;
        [SerializeField] private int maxCount = 10;
        [SerializeField] private int countToUltimateBoss = 3;
        private int _currentCount;

        private void Start()
        {
            StartCoroutine(SpawnAnimal());
        }

        private void SetInitWaypoint(GameObject animal)
        {
            var aiControl = animal.GetComponentInChildren<MAnimalAIControl>();

            if (aiControl != null && startWaypoint != null)
            {
                aiControl.SetTarget(startWaypoint);
            }
        }

        private IEnumerator SpawnAnimal()
        {
            if (bossAnimalToSpawn && startWaypoint)
            {
                while (_currentCount < maxCount)
                {
                    if (_currentCount == 0)
                    {
                        var animal = Instantiate(bossAnimalToSpawn, spawnPosition);
                        SetInitWaypoint(animal);
                        _currentCount++;
                    }

                    yield return new WaitForSeconds(spawnDelay);

                    if (_currentCount < countToUltimateBoss)
                    {
                        var animal = Instantiate(bossAnimalToSpawn, spawnPosition);
                        SetInitWaypoint(animal);
                        _currentCount++;
                    }
                    else
                    {
                        var animal = Instantiate(ultimateBossAnimalToSpawn, spawnPosition);
                        SetInitWaypoint(animal);
                        _currentCount++;
                    }
                }
            }
            else
            {
                Debug.LogWarning(
                    $"[Action Required] {gameObject.name} Please assign a Waypoint or an Animal to spawn!");
            }
        }
    }
}