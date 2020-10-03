using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] private Light2D sun;
    [SerializeField] private GameObject allLightsOnScene;
    [SerializeField] private float currentTimeOfDay = 0f;
    [SerializeField] public static float secondsInFullDay = 60f;

    private float deltaIntensityOfSun;
    private float deltaIntensityOfAllLights;

    private const float BEGIN_SUN_INTENSITY = 1f;
    private const float END_SUN_INTENSITY = 0.35f;



    private void Start() => StartCoroutine(ChangingTimeOfDay());

    private IEnumerator ChangingTimeOfDay()
    {
        deltaIntensityOfSun = Mathf.Abs(END_SUN_INTENSITY - BEGIN_SUN_INTENSITY) / secondsInFullDay;
        deltaIntensityOfAllLights = 1 / secondsInFullDay;
        sun.intensity = BEGIN_SUN_INTENSITY;
        for (currentTimeOfDay = 0f; currentTimeOfDay < secondsInFullDay; currentTimeOfDay++)
        {
            sun.intensity -= deltaIntensityOfSun;
            foreach (var light in allLightsOnScene.GetComponentsInChildren<Light2D>())
                light.intensity += deltaIntensityOfAllLights;
            yield return new WaitForSeconds(1f);
        }
    }
}
