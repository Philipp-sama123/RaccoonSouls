using System.Collections;
using MalbersAnimations.Events;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private static PlayerManager _playerInstance;
        [SerializeField] public PlayerAnimalType animalType;
        [SerializeField] public MEvent deathEvent;

        private void Awake()
        {
            // new Player Instance will be set if no one is here
            if (_playerInstance == null)
            {
                _playerInstance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(this);
        }

        public void DestroyAnimalAfterDelay(float time)
        {
            StartCoroutine(WaitForSecondsAndDestroy(time));
        }

        private IEnumerator WaitForSecondsAndDestroy(float time)
        {
            yield return new WaitForSeconds(time);
            deathEvent.Invoke(true);
            Destroy(gameObject, time);
        }
    }
}