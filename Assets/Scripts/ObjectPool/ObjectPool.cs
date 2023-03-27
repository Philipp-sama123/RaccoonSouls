using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public interface IObjectPoolNotifier
    {
        void OnEnqueuedToPool();

        void OnCreatedOrDequeuedFromPool(bool created);
    }

    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int maxCreatedCount = 5;
        private int _createdCount;
        private Queue<GameObject> _inactiveObjects = new Queue<GameObject>();

        public GameObject GetObject()
        {
            if (_inactiveObjects.Count > 0)
            {
                var dequeuedObject = _inactiveObjects.Dequeue();
                dequeuedObject.transform.parent = null; // move back to the root
                dequeuedObject.SetActive(true);

                var notifiers = dequeuedObject.GetComponents<IObjectPoolNotifier>();
                foreach (var notifier in notifiers)
                {
                    notifier.OnCreatedOrDequeuedFromPool(false);
                }
                return dequeuedObject;
            }
            else
            {
                if(_createdCount<maxCreatedCount)
                {
                    var newObject = Instantiate(prefab);
                    var poolTag = newObject.AddComponent<PooledObject>();
                    poolTag.owner = this;

                    poolTag.hideFlags = HideFlags.HideInInspector;
                    var notifiers = newObject.GetComponents<IObjectPoolNotifier>();
                    foreach (var notifier in notifiers)
                    {
                        notifier.OnCreatedOrDequeuedFromPool(true);
                      
                    }
                    _createdCount++;

                    return newObject;
                }
            }

            return null;
        }

        public void ReturnObject(GameObject objectToReturn)
        {
            var notifiers = objectToReturn.GetComponents<IObjectPoolNotifier>();

            foreach (var notifier in notifiers)
            {
                notifier.OnEnqueuedToPool();
            }

            objectToReturn.SetActive(false);
            objectToReturn.transform.parent = this.transform;
            _inactiveObjects.Enqueue(objectToReturn);
        }
    }
}