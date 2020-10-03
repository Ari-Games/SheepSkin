using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] public List<Task> tasks;
        [SerializeField] public int countSheeps;

        [SerializeField] private Text timeOfDayText;
        [SerializeField] private Text countSheepsText;
        private const int countSecondsInDay = 86400;
        private int startHour = 10;

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
                if (startHour + countHours >= 24){
                    currentTime = 0;
                    startHour = 0;
                    countHours = 0;
                }
                int countSeconds = (int)TimeSpan.FromSeconds(currentTime).TotalMinutes - countHours* 60;
                timeOfDayText.text = $"{startHour + countHours}:{countSeconds}";
                currentTime += step;
                yield return new WaitForSeconds(1f);                                                                                                           
            }

        }


    }
}