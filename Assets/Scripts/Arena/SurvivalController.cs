using Cinemachine;
using GameControl;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using Player;
using UnityEngine;

namespace Arena
{
    public class SurvivalController : MonoBehaviour
    {
        private PlayerManager _playerManager;
        private InteractableCameraManager _interactableCameraManager;
        [SerializeField] private GameObject playerSpawn;
        [SerializeField] private float startPositionXAxisCamera = 0;
        [SerializeField] private float startPositionYAxisCamera = 0.5f;

        [SerializeField] private IntVar deerGoalAmount;
        [SerializeField] private int currentDeerAmount;
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private AudioClip gameOverAudioClip;
        [SerializeField] private GameSoundManager gameSoundManager;


        private UnityEventRaiser _unityEventRaiser;
        private int deerSurvived = 0;
        private int enemiesKilled = 0;


        private void Awake()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
            _interactableCameraManager = FindObjectOfType<InteractableCameraManager>();
            _unityEventRaiser = GetComponent<UnityEventRaiser>();
        }

        private void OnEnable()
        {
            if (_playerManager && playerSpawn)
            {
                Transform playerSpawnTransform = playerSpawn.transform;
                _playerManager.gameObject.transform.position = playerSpawnTransform.position;
                _playerManager.gameObject.transform.rotation = playerSpawnTransform.rotation;

                ResetCameraPosition();
            }
        }

        private void ResetCameraPosition()
        {
            var freeLookCamera = _interactableCameraManager.GetComponent<CinemachineFreeLook>();
            if (freeLookCamera != null)
            {
                freeLookCamera.m_XAxis.Value = startPositionXAxisCamera;
                freeLookCamera.m_YAxis.Value = startPositionYAxisCamera;
            }
        }

        public void DeerReachedGoalEvent()
        {
            deerSurvived++;
        }

        public void EnemyKilledEvent()
        {
            enemiesKilled++;
        }

        public void CoinUpdateEvent(int amount)
        {
            currentDeerAmount = amount;
            if (currentDeerAmount >= deerGoalAmount)
            {
                LoadGameOverCanvas();
            }
        }

        public void LoadGameOverCanvas()
        {
            _unityEventRaiser.Time_Freeze(true);
            gameOverCanvas.SetActive(true);
            GameOverMenu gameOverMenu = gameOverCanvas.GetComponent<GameOverMenu>();
            gameOverMenu.UpdateGameOverText(enemiesKilled.ToString(), deerSurvived.ToString());
            gameSoundManager.ChangeGameMusic(gameOverAudioClip);
        }

    }
}