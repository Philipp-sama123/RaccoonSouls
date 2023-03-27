using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionControlCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMissionOne;
    [SerializeField] private TextMeshProUGUI textMissionTwo;

    public void SetMissionOneText(string text)
    {
        textMissionOne.gameObject.SetActive(true);
        textMissionOne.text = text;
    }

    public void SetMissionTwoText(string text)
    {
        textMissionTwo.gameObject.SetActive(true);
        textMissionTwo.text = text;
    }
}