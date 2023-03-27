using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesKilledText;
    [SerializeField] private TextMeshProUGUI preysSavedText;

    public void UpdateGameOverText(string enemiesKilledAmount, string preysSavedAmount)
    {
        enemiesKilledText.text = enemiesKilledAmount;
        preysSavedText.text = preysSavedAmount;
    }
}