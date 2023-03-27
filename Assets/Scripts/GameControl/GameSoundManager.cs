using Arena;
using UnityEngine;

namespace GameControl
{
    public class GameSoundManager : MonoBehaviour
    {
        private GameSound _gameSound;
        public AudioClip combatMusic;

        private void Start()
        {
            _gameSound = FindObjectOfType<GameSound>();
            ChangeGameMusic(combatMusic);
        }

        public void ChangeGameMusic(AudioClip newMusic)
        {
            if (_gameSound == null) return;

            var audioSource = _gameSound.gameObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Pause();
                audioSource.clip = newMusic;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Could not Find Audio Source!");
            }
        }
    }
}