using System;
using Player;
using UnityEngine;

namespace Menu
{
    public class ControlSettings : MonoBehaviour
    {
        // [SerializeField] private GameObject dodgeButton;
        [SerializeField] private GameObject dodgeButton;
        private PlayerManager currentPlayer;

        private void Start()
        {
            currentPlayer = FindObjectOfType<PlayerManager>();
            if (currentPlayer != null && currentPlayer.animalType == PlayerAnimalType.Jumper)
            {
                dodgeButton.SetActive(false);
            }
            else
            {
                dodgeButton.SetActive(true);
            }
        }
    }
}