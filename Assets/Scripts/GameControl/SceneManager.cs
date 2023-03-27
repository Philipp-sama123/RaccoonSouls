using Arena;
using UnityEngine;

namespace GameControl
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private string menuScene = "Main Menu";

        public void LoadMenuScene()
        {
            GameSound gameSound = FindObjectOfType<GameSound>();

            if (gameSound != null)
            {
                Destroy(FindObjectOfType<GameSound>().gameObject);
            }

            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menuScene);
        }
    }
}