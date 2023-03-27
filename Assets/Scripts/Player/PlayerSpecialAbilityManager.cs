using System.Collections;
using MalbersAnimations.Controller;
using UnityEngine;

namespace Player
{
    public class PlayerSpecialAbilityManager : MonoBehaviour
    {
        [SerializeField] private GameObject specialAbilityParticleSystem;
        private MAnimal _playerAnimal;
        private float _initialAnimatorSpeed;
        private float _animatorSpeedValueSpecialAbility = 2f;
        private bool _isActiveAbility = false;

        private void Awake()
        {
            _playerAnimal = GetComponent<MAnimal>();
            _initialAnimatorSpeed = _playerAnimal.AnimatorSpeed;
        }

        public void EnableSpecialAbility()
        {
            if (_isActiveAbility == false)
            {
                _playerAnimal.AnimatorSpeed = _animatorSpeedValueSpecialAbility;
                StartCoroutine(SpecialAbility());
            }
        }
        

        private IEnumerator SpecialAbility()
        {
            _isActiveAbility = true;
            specialAbilityParticleSystem.SetActive(true);
            _playerAnimal.AnimatorSpeed = _animatorSpeedValueSpecialAbility;

            yield return new WaitForSeconds(10);

            specialAbilityParticleSystem.SetActive(false);
            _playerAnimal.AnimatorSpeed = _initialAnimatorSpeed;
            _isActiveAbility = false;
        }
    }
}