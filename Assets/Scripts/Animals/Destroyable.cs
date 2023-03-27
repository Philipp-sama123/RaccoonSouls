using UnityEngine;

namespace Animals
{
    public class Destroyable : MonoBehaviour
    {
        public void DestroyImmediately()
        {
            Destroy(gameObject);
        }    public void DestroyAfterSeconds(float delay)
        {
            Destroy(gameObject, delay);
        }
    }
}