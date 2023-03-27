using System.Collections;
using Arena;
using MalbersAnimations.Controller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField] private string menuScene = "Main Menu";
        [SerializeField] GameObject loadingScreen;
        [SerializeField] Slider slider;
        [SerializeField] GameObject progressTextComponent;


        public void LoadMenuScene()
        {
            GameSound gameSound = FindObjectOfType<GameSound>();
            if (gameSound != null)
            {
                Destroy(gameSound.gameObject);
            }

            StartCoroutine(LoadAsynchronously(menuScene));
        }
        
        public void PlayGame(string sceneName)
        {
            StartCoroutine(LoadAsynchronously(sceneName));
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private IEnumerator LoadAsynchronously(string sceneName)
        {
            yield return null;

            loadingScreen.SetActive(true);
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            ao.allowSceneActivation = false;
            Debug.Log(sceneName);
            do
            {
                float progress = Mathf.Clamp01(ao.progress / 0.9f);
                slider.value = progress;
                if (GetComponent<TextMeshProUGUI>() != null)
                {
                    var progressText = GetComponent<TextMeshProUGUI>().text;
                    progressText = Mathf.RoundToInt(progress * 100) + " %";
                }

                if (ao.progress >= 0.9f)
                {
                    ao.allowSceneActivation = true;
                }

                yield return null;
            } while (!ao.isDone);
        }
    }
}