using System.Collections;
using MalbersAnimations.Controller.AI;
using UnityEngine;

namespace GameControl
{
    public class AnimalSpawner : MonoBehaviour
    {
        [Header("Spawning General")] [SerializeField]
        private GameObject animalToSpawn;

        [SerializeField] private GameObject startWaypoint;
        [SerializeField] private Transform spawnPosition;
        
        [SerializeField] private int maxCountSpawnable = 10;

        private int _currentCount;
        
        public void InstantiateAndActivateAnimal(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var animal = Instantiate(animalToSpawn, spawnPosition);
                SetInitWaypoint(animal);
                _currentCount++;
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