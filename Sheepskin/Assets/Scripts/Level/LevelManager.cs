using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Flocking;
using Goap;
using UnityEngine.SceneManagement;
using Assets.Scripts.Tasks;
namespace Assets.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Task tasks;
        [SerializeField] private int countSheeps;

        [SerializeField] private Text timeOfDayText;
        [SerializeField] private Text countSheepsText;
        [SerializeField] private int startHour = 10;
        [SerializeField] private int countGameHour = 27;

        [SerializeField] private Image panelTime;
        [SerializeField] private Image panelSheeps;
        [SerializeField] private Sprite nightTime;
        [SerializeField] private Sprite nightSheeps;

        [SerializeField] private GameObject endGame;

        [SerializeField] private GameObject blockFences;
        [SerializeField] private GameObject exit;
        private int allCountSheep;


        private void Start()
        {
            GameObject.FindGameObjectWithTag("Core").GetComponent<UpdateWorld>().PlayRandomClip();
            Player.Player.Instance.NewGame();
            allCountSheep = tasks.Progress();
            countSheepsText.text = allCountSheep.ToString();

            StartCoroutine(ChangingOfTime());
        }

        private void Update()
        {
            if (tasks.IsComplete())
            {
                blockFences.SetActive(false);
                exit.SetActive(true);
            }
            if (Player.Player.Instance.IsLife == false)
            {
                endGame.SetActive(true);
                StartCoroutine(EndGame());
            }
            countSheepsText.text = tasks.Progress().ToString();
        }

        private IEnumerator EndGame()
        {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(2);
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
                var zeroAfterSecond = countSeconds / 10 == 0 ? "0" : "";
                timeOfDayText.text = $"{startHour + countHours}:{zeroAfterSecond + countSeconds}";
                currentTime += step;
                yield return new WaitForSeconds(1f);                                                                                                           
            }
            endGame.SetActive(true);
            StartCoroutine(EndGame());

        }


    }
}