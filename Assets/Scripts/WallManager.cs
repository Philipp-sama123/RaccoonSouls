using System.Collections;
using MalbersAnimations;
using MalbersAnimations.Events;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private float disableTime = 10f;
    [SerializeField] private GameObject wall;
    [SerializeField] private MEvent wallDestroyEvent;
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
        wallDestroyEvent.Invoke(1);
        yield return new WaitForSecondsRealtime(disableTime);

        stats.Restart();
        wall.SetActive(true);
    }
}