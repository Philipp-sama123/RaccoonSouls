using System.Collections;
using Arena;
using TMPro;
using UnityEngine;

namespace GameControl
{
    public class LevelGoalController : MonoBehaviour
    {
        [SerializeField] private int deersReachedGoal;
        [SerializeField] private int enemiesKilled;
        [SerializeField] private int enemiesLimit = 20;
        [SerializeField] private int deerLimit = 10;

        [SerializeField] private GameObject goalDisplay;
        [SerializeField] private GameObject enemyCounterDisplay;
        [SerializeField] private int timeInSeconds = 0;


        public void Start()
        {
            StartCoroutine(Time());
            SetEnemyText();
            SetDeerText();
        }

        private IEnumerator Time()
        {
            while (true)
            {
                TimeCount();
                yield return new WaitForSeconds(1);
            }
        }

        void TimeCount()
        {
            timeInSeconds += 1;
        }

        public void DeerReachedGoal()
        {
            deersReachedGoal++;
            SetDeerText();
        }

        private void SetDeerText()
        {
            string deerDisplayText =
                $"{deersReachedGoal.ToString()} / {deerLimit.ToString()}";

            if (deersReachedGoal >= deerLimit)
            {
                deerDisplayText =
                    $"{timeInSeconds}s.";
            }

            if (goalDisplay != null)
            {
                var text = goalDisplay.GetComponent<TextMeshProUGUI>();
                text.SetText(deerDisplayText);
            }
        }

        public void EnemyKilled()
        {
            enemiesKilled++;
            SetEnemyText();
        }

        private void SetEnemyText()
        {
            string displayText =
                $"{enemiesKilled.ToString()} / {enemiesLimit.ToString()}";

            if (enemiesKilled >= enemiesLimit)
            {
                displayText =
                    $"{timeInSeconds}s.";
            }

            if (enemyCounterDisplay != null)
            {
                var text = enemyCounterDisplay.GetComponent<TextMeshProUGUI>();
                text.SetText(displayText);
            }
        }
    }
}