using System.Collections;
using MalbersAnimations.Controller;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace Player
{
    public class PlayerSpecialAbilityManager : MonoBehaviour
    {
        [SerializeField] private GameObject specialAbilityParticleSystem;
        [SerializeField] private FloatVar attackOneCoolDown;
        private MAnimal _playerAnimal;
        private float _initialAnimatorSpeed;
        private float _animatorSpeedValueSpecialAbility = 2f;
        private float _initialAttackOneCoolDown;
        private bool _isActiveAbility = false;

        private void Awake()
        {
            _playerAnimal = GetComponent<MAnimal>();
            _initialAnimatorSpeed = _playerAnimal.AnimatorSpeed;
            if (attackOneCoolDown)
                _initialAttackOneCoolDown = attackOneCoolDown.Value;
        }

        public void EnableSpecialAbility()
        {
            if (_isActiveAbility == false)
            {
                StartCoroutine(SpecialAbility());
            }
        }


        private IEnumerator SpecialAbility()
        {
            _isActiveAbility = true;
            specialAbilityParticleSystem.SetActive(true);
            _playerAnimal.AnimatorSpeed = _animatorSpeedValueSpecialAbility;

            if (attackOneCoolDown)
                attackOneCoolDown.Value = 0f;

            yield return new WaitForSeconds(10);

            specialAbilityParticleSystem.SetActive(false);
            _playerAnimal.AnimatorSpeed = _initialAnimatorSpeed;
            if (attackOneCoolDown)
                attackOneCoolDown.Value = _initialAttackOneCoolDown;

            _isActiveAbility = false;
        }
    }
}