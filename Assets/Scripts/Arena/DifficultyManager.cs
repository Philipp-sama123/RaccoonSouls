using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionText;
    [SerializeField] private IntVar deerMaxGoalAmount;
    [SerializeField] private IntVar abilityPoints; 
    [SerializeField] private string missionTextTemplate = "Select your Difficulty:";
    [SerializeField] private UnityEventRaiser eventRaiser;
    [SerializeField] private Image starOneImage; 
    [SerializeField] private Image starTwoImage; 
    [SerializeField] private Image starThreeImage;

    public void UpdateDifficulty(int difficultyLevel)
    {
        if (difficultyLevel == 1)
        {
            deerMaxGoalAmount.Value = 5;
            abilityPoints.Value = 5;
            missionTextTemplate = $"Level 1.\nSave {deerMaxGoalAmount.Value} Animals";
            starOneImage.enabled = true; 
            starTwoImage.enabled = false; 
            starThreeImage.enabled = false; 
        }
        else if (difficultyLevel == 2)
        {
            deerMaxGoalAmount.Value = 10;
            abilityPoints.Value = 3;
            missionTextTemplate = $"Level 2.\nSave {deerMaxGoalAmount.Value} Animals";
            
            starOneImage.enabled = true; 
            starTwoImage.enabled = true; 
            starThreeImage.enabled = false; 
        }
        else if (difficultyLevel == 3)
        {
            deerMaxGoalAmount.Value = 15;
            abilityPoints.Value = 1;
            missionTextTemplate = $"Level 3.\nSave {deerMaxGoalAmount.Value} Animals";
            starOneImage.enabled = true; 
            starTwoImage.enabled = true; 
            starThreeImage.enabled = true; 
        }
        missionText.SetText(missionTextTemplate);
    }
}