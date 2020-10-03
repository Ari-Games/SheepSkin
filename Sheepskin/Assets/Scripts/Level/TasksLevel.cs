using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.Level
{
    public class TasksLevel : MonoBehaviour
    {
        [SerializeField] public List<Task> tasks;
        [SerializeField] public int countSheeps;

        [SerializeField] private Text timeOfDayText;
        [SerializeField] private Text countSheepsText;
        private const int countSecondsInDay = 86400;

        private void Start()
        {
            countSheepsText.text = countSheeps.ToString();
            foreach (var task in tasks)
                Debug.Log(task);
            StartCoroutine(ChangingOfTime());
        }

        private IEnumerator ChangingOfTime()
        {
            float step = countSecondsInDay / DayNightManager.secondsInFullDay;
            float currentTime = 0f;
            for (int currentTimeInSeconds = 0; currentTimeInSeconds < DayNightManager.secondsInFullDay; currentTimeInSeconds++)
            {
                int countHours = (int)TimeSpan.FromSeconds(currentTime).TotalHours;
                int countSeconds = (int)TimeSpan.FromSeconds(currentTime).TotalMinutes - countHours* 60;
                timeOfDayText.text = $"{countHours}:{countSeconds}";
                currentTime += step;
                yield return new WaitForSeconds(1f);                                                                                                           
            }

        }


    }
}