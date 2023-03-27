using Arena;
using Player;
using UnityEngine;

namespace Menu
{
    public class MainMenuController : MonoBehaviour
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

        public void Start()
        {
            if (_playerManager)
                Destroy(_playerManager.gameObject);

            if (_interactableCameraManager)
                Destroy(_interactableCameraManager.gameObject);

            if (_cameraManager)
                Destroy(_cameraManager.gameObject);
        }
    }
}