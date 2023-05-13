using System;
using System.Collections;
using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Animals
{
    public class AnimalHelper : MonoBehaviour
    {
        [SerializeField] public AnimalType animalType = AnimalType.Enemy;
        [SerializeField] private float delayTime = 2.5f;
        [SerializeField] private GameObject deathObject;
        [SerializeField] private GameObject successObject;
        [SerializeField] private MEvent enemyDeathEvent;
        [SerializeField] private MEvent preyDied;
        [SerializeField] private MEvent deerReachedGoalEvent;
        [SerializeField] private GameObject[] visibleGameObjects;
        [SerializeField] private GameObject successParticleSystem;
        [SerializeField] private GameObject deathParticleSystem;
        
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }

        public AnimalType GetAnimalType()
        {
            return animalType;
        }

        private void OnBecameVisible()
        {
            if (!_navMeshAgent.isActiveAndEnabled)
            {
                Debug.LogWarning(_navMeshAgent);
                _navMeshAgent.enabled = true;
            }
            else
            {
                Debug.LogWarning("Remove me");
            }
        }

        public void DestroyEnemyAnimal()
        {
            StartCoroutine(DestroyAfterSeconds());
        }

        private IEnumerator DestroyAfterSeconds()
        {
            if (deathParticleSystem != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
            {
                deathParticleSystem.SetActive(true);
            }

            foreach (var visibleGameObject in visibleGameObjects)
            {
                visibleGameObject.SetActive(false);
            }

            yield return new WaitForSeconds(delayTime);


            if (enemyDeathEvent != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
            {
                enemyDeathEvent.Invoke();
            }

            if (deathObject != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
            {
                Vector3 instantiationPosition = transform.position;
                Instantiate(deathObject, instantiationPosition, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        public void DestroyAnimalPrey(bool reachedGoal)
        {
            StartCoroutine(DestroyPrey(reachedGoal));
        }

        private IEnumerator DestroyPrey(bool reachedGoal)
        {
            foreach (var visibleGameObject in visibleGameObjects)
            {
                visibleGameObject.SetActive(false);
            }

            if (successParticleSystem != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
            {
                successParticleSystem.SetActive(true);
            }

            yield return new WaitForSeconds(delayTime);


            if (reachedGoal)
            {
                if (successObject != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
                {
                    Vector3 instantiationPosition = transform.position;
                    Instantiate(successObject, instantiationPosition, Quaternion.identity);
                }

                if (deerReachedGoalEvent !=
                    null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
                    deerReachedGoalEvent.Invoke(); // ToDo: Malbers Event Raiser
            }
            else
            {
                if (deathObject != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
                {
                    Vector3 instantiationPosition = transform.position;
                    Instantiate(deathObject, instantiationPosition, Quaternion.identity);
                }

                if (preyDied != null) // ToDo: Improve Null Checks, Maybe go sure its assigned/defined on awake
                {
                    preyDied.Invoke(); // ToDo: Malbers Event Raiser
                }
            }

            Destroy(gameObject);
        }
    }
}