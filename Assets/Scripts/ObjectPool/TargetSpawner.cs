using System.Collections;
using UnityEngine;

namespace ObjectPool
{
    public class TargetSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool pool;

        public void SpawnAtTargetPosition(Transform spawnTransform)
        {
            var o = pool.GetObject();
            if (o != null)
                o.transform.position = spawnTransform.position;
            else
            {
                Debug.LogError("Could not create Object!");
            }
        }

        public void SpawnAtTargetPositionDelayed(Transform spawnTransform)
        {
            StartCoroutine(WaitAndSpawnAtTarget(spawnTransform, 3f));
        }


        private IEnumerator WaitAndSpawnAtTarget(Transform spawnTransform, float delay)
        {
            yield return new WaitForSeconds(delay);
            SpawnAtTargetPosition(spawnTransform);
        }
    }
}