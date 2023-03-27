using Player;
using UnityEngine;

namespace GameControl
{
    public class OnTriggerEnterSceneLoader : MonoBehaviour
    {
        [SerializeField] private string nextSceneName = "Game Over Scene";

        private void OnTriggerEnter(Collider other)
        {
            if (other.FindComponent<PlayerManager>())
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneName);
        }
    }
}