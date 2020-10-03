using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] private Light2D sun;
    [SerializeField] private float secondsInFullDay = 60f;
    [SerializeField] private float currentTimeOfDay = 0f;
    [SerializeField] private float deltaTimeInDay;
    [SerializeField] private float secondsInDay;

    private const float BEGIN_SUN_INTENSITY = 1f;
    private const float END_SUN_INTENSITY = 0.35f;



    private void Start() => StartCoroutine(ChangingTimeOfDay());

    private IEnumerator ChangingTimeOfDay()
    {
        deltaTimeInDay = Mathf.Abs(END_SUN_INTENSITY - BEGIN_SUN_INTENSITY) / secondsInFullDay;
        sun.intensity = BEGIN_SUN_INTENSITY;
        for (currentTimeOfDay = 0f; currentTimeOfDay < secondsInFullDay; currentTimeOfDay++)
        {
            sun.intensity -= deltaTimeInDay;
            yield return new WaitForSeconds(1f);
        }
    }
}
