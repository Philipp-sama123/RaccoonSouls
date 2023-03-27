using UnityEngine;

namespace Arena
{
    public class GameSound : MonoBehaviour
    {
        [SerializeField] AudioClip quietTheme;
        private static GameSound _gameSoundInstance;

        void Awake()
        {
            DontDestroyOnLoad(this);

            if (_gameSoundInstance == null)
            {
                _gameSoundInstance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}