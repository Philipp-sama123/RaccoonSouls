using System.Collections;
using MalbersAnimations;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private float disableTime = 5f;
    [SerializeField] private GameObject wall;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private Stats stats;

    public void DisableAndEnableWall()
    {
        StartCoroutine(DisableAndEnableSelf());
    }

    private IEnumerator DisableAndEnableSelf()
    {
        wall.SetActive(false);
        particleSystem.Play();
        yield return new WaitForSecondsRealtime(disableTime);

        stats.Restart();
        wall.SetActive(true);
    }
}