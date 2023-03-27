using UnityEngine;

namespace ObjectPool
{
    public class PooledObject : MonoBehaviour
    {
        public global::ObjectPool.ObjectPool owner;
    }

    public static class PooledObjectExtensions
    {
        public static void ReturnToPool(this GameObject gameObject)
        {
            var pooledObject = gameObject.GetComponent<PooledObject>();
            if (pooledObject == null)
            {
                Debug.LogErrorFormat(gameObject,
                    "Cannot return {0} to object Pool, because it was not created from one!",
                    gameObject);
            }
            else
            {
                pooledObject.owner.ReturnObject(gameObject);
            }
        }
    }
}