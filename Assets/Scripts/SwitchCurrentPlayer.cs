using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Player;
using UnityEngine;

public class SwitchCurrentPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] playerAnimals;
    [SerializeField] private CinemachineFreeLook _freeLookCamera;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    private int _currentIndex = 0;


    private GameObject _currentPlayer;

    private void OnEnable()
    {
        _currentPlayer = FindObjectOfType<PlayerManager>().gameObject;
        _freeLookCamera = FindObjectOfType<CinemachineFreeLook>();
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void SpawnAnimal()
    {
        _freeLookCamera.gameObject.SetActive(false);
        _virtualCamera.gameObject.SetActive(false);
        
        
        DestroyImmediate(_currentPlayer);
        _currentPlayer = Instantiate(playerAnimals[_currentIndex]);
        
        _freeLookCamera.gameObject.SetActive(true);
        _virtualCamera.gameObject.SetActive(true);
        
        
        _currentIndex++;
        if (_currentIndex > (playerAnimals.Length - 1))
        {
            _currentIndex = 0;
        }
    }
}