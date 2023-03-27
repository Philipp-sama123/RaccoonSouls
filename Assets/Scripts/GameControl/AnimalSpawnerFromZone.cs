using System.Collections;
using MalbersAnimations.Controller.AI;
using UnityEngine;

namespace GameControl
{
    public class AnimalSpawnerFromZone : MonoBehaviour
    {
        [Header("Spawning General")] [SerializeField]
        private GameObject[] animalsToSpawn;

        [SerializeField] private GameObject startWaypoint;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private int maxCount = 15;


        private int _currentCount;

        public void InstantiateAndActivateAnimal(int amount)
        {
            if (_currentCount < maxCount)
            {
                for (int i = 0; i < amount; i++)
                {
                    var animal = Instantiate(animalsToSpawn[Random.Range(0, animalsToSpawn.Length)], spawnPosition);
                    SetInitWaypoint(animal);
                    _currentCount++;
                }
            }
            else
            {
                Debug.LogWarning("Max Count reached!TODO!! Destroy Zone");
            }
        }

        private void SetInitWaypoint(GameObject animal)
        {
            var aiControl = animal.GetComponentInChildren<MAnimalAIControl>();

            if (aiControl != null)
            {
                aiControl.SetTarget(startWaypoint);
            }
        }
    }
}