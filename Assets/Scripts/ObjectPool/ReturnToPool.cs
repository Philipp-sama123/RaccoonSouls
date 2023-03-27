using System.Collections;
using _Game.Scripts;
using UnityEngine;

namespace ObjectPool
{
    public class ReturnToPool : MonoBehaviour, IObjectPoolNotifier
    {
        [SerializeField] private float delayTime = 3f;
        private PoolableEnemyHelper _poolableEnemyHelper = null;
      
        private void Awake()
        {
            _poolableEnemyHelper = GetComponent<PoolableEnemyHelper>(); 
        }

        public void OnEnqueuedToPool()
        {
            Debug.Log("Enqueued to object Pool");
        }

        public void OnCreatedOrDequeuedFromPool(bool created)
        {
            Debug.Log("Dequeued from object Pool");
            if (_poolableEnemyHelper != null)
            {
                _poolableEnemyHelper.ActivateComponents();
            }
        }

        public void ReturnObjectToPool()
        {
            StartCoroutine(ReturnToPoolAfterDelay());
        }

        private IEnumerator ReturnToPoolAfterDelay()
        {
            yield return new WaitForSeconds(delayTime);
            gameObject.ReturnToPool();
        }
    }
}