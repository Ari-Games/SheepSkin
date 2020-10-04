using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Flocking;
using Goap;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Task> tasks;
        [SerializeField] private int countSheeps;

        [SerializeField] private Text timeOfDayText;
        [SerializeField] private Text countSheepsText;
        [SerializeField] private int startHour = 10;
        [SerializeField] private int countGameHour = 27;

        [SerializeField] private Image panelTime;
        [SerializeField] private Image panelSheeps;
        [SerializeField] private Sprite nightTime;
        [SerializeField] private Sprite nightSheeps;
        [SerializeField] private FlockController flockController;

        [SerializeField] private GameObject endGame;

        private void Start()
        {
            countSheepsText.text = GWorld.sheepLeftCount.ToString();
            foreach (var task in tasks)
                Debug.Log(task);
            StartCoroutine(ChangingOfTime());
        }

        private void Update()
        {
            if (Goap.GWorld.sheepLeftCount == 0)
            {
                endGame.SetActive(true);
                StartCoroutine(EndGame());
            }
            if (GWorld.isLife == false)
            {
                endGame.SetActive(true);
                StartCoroutine(EndGame());
            }
            countSheepsText.text = GWorld.sheepLeftCount.ToString();
        }

        private IEnumerator EndGame()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(2);
            yield return new WaitForSeconds(2f);
        }

        private IEnumerator ChangingOfTime()
        {
            float step = (countGameHour * 3600 - startHour * 3600) / DayNightManager.secondsInFullDay;
            float currentTime = 0f;
            for (int currentTimeInSeconds = 0; currentTimeInSeconds < DayNightManager.secondsInFullDay; currentTimeInSeconds++)
            {
                int countHours = (int)TimeSpan.FromSeconds(currentTime).TotalHours;
                if (startHour + countHours >= 17)
                {
                    panelSheeps.GetComponent<Image>().sprite = nightSheeps;
                    panelTime.sprite = nightTime;
                }
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
            endGame.SetActive(true);
            StartCoroutine(EndGame());

        }


    }
}