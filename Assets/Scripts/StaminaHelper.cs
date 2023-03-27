using UnityEngine;

public class StaminaHelper : MonoBehaviour
{
    [SerializeField] private GameObject staminaStat;

    public void UpdateStaminaStat(float currentStamina)
    {
        if (staminaStat != null)
            if (currentStamina <1)
            {
                staminaStat.SetActive(true);
            }
            else
            {
                staminaStat.SetActive(false);
            }
    }
}