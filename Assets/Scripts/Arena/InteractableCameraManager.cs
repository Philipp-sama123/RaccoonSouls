using Cinemachine;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arena
{
    public class InteractableCameraManager : MonoBehaviour
    {
        private InteractableCameraManager _instance;

        private CinemachineFreeLook _freeLookCamera;
        private CinemachineVirtualCamera _virtualCamera;
        private PlayerManager _playerManager;

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
        

        private void OnEnable()
        {
            _freeLookCamera = GetComponent<CinemachineFreeLook>();
            _playerManager = FindObjectOfType<PlayerManager>();
            if (_playerManager)
            {
                _virtualCamera = GetComponent<CinemachineVirtualCamera>();
                _freeLookCamera = GetComponent<CinemachineFreeLook>();
                if (_virtualCamera)
                {
                    var playerManagerTransform = _playerManager.transform;
                    _virtualCamera.LookAt = playerManagerTransform;
                    _virtualCamera.Follow = playerManagerTransform;
                }
                else if (_freeLookCamera)
                {
                    var playerManagerTransform = _playerManager.transform;
                    _freeLookCamera.LookAt = playerManagerTransform;
                    _freeLookCamera.Follow = playerManagerTransform;
                }
            }
            
            _freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }

        public void ToggleCameraRecenter()
        {
            _freeLookCamera.m_RecenterToTargetHeading.m_enabled = !_freeLookCamera.m_RecenterToTargetHeading.m_enabled;
        }
    }
}