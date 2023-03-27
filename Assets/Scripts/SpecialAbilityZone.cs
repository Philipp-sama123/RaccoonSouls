using System;
using System.Collections;
using System.Collections.Generic;
using Animals;
using Player;
using UnityEngine;

public class SpecialAbilityZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AnimalHelper enemy = other.GetComponentInParent<AnimalHelper>();
        if (enemy != null && enemy.animalType == AnimalType.Enemy)
        {
            PlayerSpecialAbilityManager playerSpecialAbilityManager =
                other.GetComponentInParent<PlayerSpecialAbilityManager>();
            if (playerSpecialAbilityManager != null)
            {
                playerSpecialAbilityManager.EnableSpecialAbility();
            }
        }
    }
}