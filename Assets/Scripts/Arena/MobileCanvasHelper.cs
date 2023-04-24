using Player;
using UnityEngine;

namespace Arena
{
    public class MobileCanvasHelper : MonoBehaviour
    {
        private PlayerManager _playerManager;
        private InteractableCameraManager _interactableCameraManager;
        private CameraBrainManager _cameraManager;


        private void Awake()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
            _interactableCameraManager = FindObjectOfType<InteractableCameraManager>();
            _cameraManager = FindObjectOfType<CameraBrainManager>();
        }

        private void Start()
        {
            // Enable Camera Recenter onStart
            ToggleCameraRecenter();
        }

        public void DestroyAllIndestructibleObjects()
        {
            if (_playerManager)
                Destroy(_playerManager.gameObject);

            if (_interactableCameraManager)
                Destroy(_interactableCameraManager.gameObject);

            if (_cameraManager)
                Destroy(_cameraManager.gameObject);
        }

        public void ToggleCameraRecenter()
        {
            if (_interactableCameraManager != null)
            {
                _interactableCameraManager.ToggleCameraRecenter();
            }
            else
            {
                Debug.LogWarning("No camera defined!");
            }
        }
    }
}