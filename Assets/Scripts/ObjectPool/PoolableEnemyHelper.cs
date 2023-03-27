using MalbersAnimations.Controller.AI;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts
{
    public class PoolableEnemyHelper : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }

        public void ActivateComponents()
        {
            ActivateBrainComponents();
        }

        private void ActivateBrainComponents()
        {
            MAnimalBrain brain = GetComponentInChildren<MAnimalBrain>();
            MAnimalAIControl aiControl = GetComponentInChildren<MAnimalAIControl>();

            Debug.LogWarning(brain.enabled + " " + aiControl.enabled);

            if (brain && !brain.enabled)
            {
                brain.enabled = true;
            }

            if (aiControl)
            {
                aiControl.ResetAIValues();
                if (!aiControl.enabled)
                {
                    aiControl.enabled = true;
                }
            }
        }


        // ToDo: in the best case remove totally (!) Perfomance you idiot (!)
        private void OnBecameVisible()
        {
            Debug.LogWarning(_navMeshAgent);
            if (!_navMeshAgent.isActiveAndEnabled)
            {
                _navMeshAgent.enabled = true;
            }
        }
    }
}