using UnityEngine;

namespace Arena
{
    public class CameraBrainManager : MonoBehaviour
    {
        private static CameraBrainManager _instance;

        void Awake()
        {
            // new Player Instance will be set if no one is here
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);
        }
    }
}

