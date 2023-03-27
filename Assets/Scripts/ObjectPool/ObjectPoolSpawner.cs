using System.Collections;
using MalbersAnimations.Controller.AI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ObjectPool
{
    public class ObjectPoolSpawner : MonoBehaviour
    {
        [SerializeField] private global::ObjectPool.ObjectPool pool;
        [SerializeField] private bool isInstant = false;
        [SerializeField] private GameObject startwaypoint;
        [SerializeField] private float[] delayRange = {10f, 200f};

        private IEnumerator Start()
        {
            if (startwaypoint)
            {
                while (true)
                {
                    var o = pool.GetObject();

                    var position = transform.position;
                    o.transform.position = position;

                    var delay = Random.Range(delayRange[0], delayRange[1]);
                    
                    SetInitWaypoint(o);
                    
                    if (isInstant)
                    {
                        yield return new WaitForSeconds(0);
                    }
                    else
                    {
                        yield return new WaitForSeconds(delay);
                    }
                }
            }

            while (true)
            {
                var o = pool.GetObject();

                var position = transform.position;
                o.transform.position = position;

                var delay = Random.Range(delayRange[0], delayRange[1]);

                if (isInstant)
                {
                    yield return new WaitForSeconds(0);
                }
                else
                {
                    yield return new WaitForSeconds(delay);
                }
            }
        }

        private void SetInitWaypoint(GameObject o)
        {
            var aiControl = o.GetComponentInChildren<MAnimalAIControl>();
            if (aiControl)
            {
                aiControl.SetTarget(startwaypoint);
            }
        }
    }
}