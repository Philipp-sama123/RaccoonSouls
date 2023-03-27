using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private AudioSource spawnSound;
    [SerializeField] private Transform[] objectToSpawnTransforms;

    [SerializeField] private int maxUsageCount = 5;
    [SerializeField] private ParticleSystem destroyParticleSystem;
    [SerializeField] private AudioSource destroySound;

    private int _usedAmount = 0;

    public void SpawnObjects()
    {
        spawnSound.Play();
        _usedAmount++;

        if (_usedAmount < maxUsageCount)
        {
            foreach (var spawnTransform in objectToSpawnTransforms)
            {
                var index = Random.Range (0, objectsToSpawn.Length);
                var randomObjectToSpawn = objectsToSpawn[index];
                
                var instantiated = Instantiate(randomObjectToSpawn, spawnTransform);
                instantiated.transform.parent = null;
            }
        }
        else
        {
            destroyParticleSystem.Play();
            destroySound.Play();
            Destroy(gameObject, destroyParticleSystem.main.duration);
        }
    }
}