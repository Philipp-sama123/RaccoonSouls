using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityButton : MonoBehaviour
{
    private Button _button;
    [SerializeField] private Image lockImage;
    public float disableTime = 25f;
    public int currentDisableTIme = 0;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }


    public void DisableForSeconds()
    {
        lockImage.gameObject.SetActive(true);
        _button.enabled = false;
        
        StartCoroutine(Time());
    }


    private IEnumerator Time()
    {
        while (true)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
            if (currentDisableTIme > disableTime)
            {
                lockImage.gameObject.SetActive(false);
                _button.enabled = true;
                currentDisableTIme = 0; 
                break;
            }

            lockImage.fillAmount =1- (currentDisableTIme / disableTime);
        }
    }

    void TimeCount()
    {
        currentDisableTIme += 1;
    }
}