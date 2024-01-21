using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsActivator : MonoBehaviour
{
    public bool weatherEvents;

    [Header("Components")]
    public GameObject carLightLeft;
    public GameObject carLightRight;
    public PlayerMovement player;
    public GameObject rainUI;
    public GameObject rainEffect;
    public GameObject rainPP;
    public GameObject snowPP;
    public GameObject mistPP;
    public GameObject mistUI;
    public GameObject snowUI;
    public GameObject lightUI;

    [Header("FogStats")]
    public float defaultFogDensity;
    public float mistFogDensity;
    public float rainFogDensity;
    public float snowFogDensity;
    public float singleCarLightGone;
    public float bothCarLightGone;

    public float actualFogDensity;

    [Header("CarStats")]
    public float deccelRateNormal;
    public float deccelRateRain;
    public float deccelRateSnow;
    public float accelrateNormal;
    public float accelrateRain;
    public float accelrateSnow;

    [Header("Car/Weather Conditions")]
    public bool isSnowing = false;
    public bool isRaining = false;
    public bool isMist = false;
    public bool leftCarLight = true;
    public bool rightCarLight = true;
    private void Start()
    {
        RenderSettings.fogDensity = defaultFogDensity;
        int buildIndexRightNow;
        buildIndexRightNow = SceneManager.GetActiveScene().buildIndex;
        if (buildIndexRightNow == 1)
        {
            if (weatherEvents)
            {
                StartCoroutine(GameEvent());
            }
            Debug.Log("shi crazy");
        }
    }

    private void Update()
    {
        actualFogDensity = RenderSettings.fogDensity;
    }
    public void StartRain()
    {
        rainUI.SetActive(true);
        rainEffect.SetActive(true);
        rainPP.SetActive(true);
        isRaining = true;
        player.accelAmount = accelrateRain;
        player.deccelAmount = deccelRateRain;
        CheckLights();
    }
    public void StopRain()
    {
        rainUI.SetActive(false);
        rainEffect.SetActive(false);
        rainPP.SetActive(false);
        isRaining = false;
        player.accelAmount = accelrateNormal;
        player.deccelAmount = deccelRateNormal;
        CheckLights();
    }

    public void StartSnow()
    {
        StopRain();
        snowPP.SetActive(true);
        snowUI.SetActive(true);
        isSnowing = true;
        player.accelAmount = accelrateSnow;
        player.deccelAmount = deccelRateSnow;
        CheckLights();
    }

    public void StopSnow()
    {
        snowUI.SetActive(false);
        snowPP.SetActive(false);
        isSnowing = false;
        player.accelAmount = accelrateNormal;
        player.deccelAmount = deccelRateNormal;
        CheckLights();
    }
    public void StartFog()
    {
        mistUI.SetActive(true);
        mistPP.SetActive(true);
        isMist = true;
        CheckLights();
    }

    public void StopFog()
    {
        mistPP.SetActive(false);
        mistUI.SetActive(false);
        isMist = false;
        CheckLights();
    }

    public void LeftCarLightOff()
    {
        carLightLeft.SetActive(false);
        leftCarLight = false;
        CheckLights();
    }
    public void LeftCarLightOn()
    {
        carLightLeft.SetActive(true);
        leftCarLight = true;
        CheckLights();
    }
    public void RightCarLightOff()
    {
        carLightRight.SetActive(false);
        rightCarLight = false;
        CheckLights();
    }
    public void RightCarLightOn()
    {
        carLightRight.SetActive(true);
        rightCarLight = true;
        CheckLights();
    }

    public void CheckLights()
    {
        if (!rightCarLight && !leftCarLight)
        {
            RenderSettings.fogDensity = bothCarLightGone;
        }
        else if (isMist)
        {
            RenderSettings.fogDensity = mistFogDensity;
            lightUI.SetActive(false);
        }
        else if (!rightCarLight || !leftCarLight)
        {
            RenderSettings.fogDensity = singleCarLightGone;
            lightUI.SetActive(true);
        }
        else if (isRaining)
        {
            RenderSettings.fogDensity = rainFogDensity;
            lightUI.SetActive(false);
        }
        else if (isSnowing)
        {
            RenderSettings.fogDensity = snowFogDensity;
            lightUI.SetActive(false);
        }
        else
        {
            RenderSettings.fogDensity = defaultFogDensity;
            lightUI.SetActive(false);
        }
    }

    private IEnumerator GameEvent()
    {
        yield return new WaitForSeconds(15f);
        LeftCarLightOff();
        yield return new WaitForSeconds(10f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(15f);
        StartFog();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(10f);
        StartSnow();
        yield return new WaitForSeconds(25f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(5f);
        RightCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        StartFog();
        yield return new WaitForSeconds(10f);
        StartSnow();
        yield return new WaitForSeconds(25f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(20f);
        LeftCarLightOff();
        StartSnow();
        RightCarLightOff();
        yield return new WaitForSeconds(30f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        StartFog();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(5f);
        StartSnow();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        StartSnow();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(20f);
        LeftCarLightOff();
        StartSnow();
        RightCarLightOff();
        yield return new WaitForSeconds(30f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        StartFog();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(2f);
        RightCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        StartFog();
        yield return new WaitForSeconds(10f);
        StartSnow();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        yield return new WaitForSeconds(15f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(20f);
        LeftCarLightOff();
        StartSnow();
        RightCarLightOff();
        yield return new WaitForSeconds(30f);
        RightCarLightOff();
        yield return new WaitForSeconds(10f);
        StartFog();
        yield return new WaitForSeconds(10f);
        LeftCarLightOff();
        yield return new WaitForSeconds(2f);
        RightCarLightOff();
        yield return new WaitForSeconds(25f);
        StartRain();
        StartFog();
    }

    private void AllOfForTest()
    {
        LeftCarLightOn();
        RightCarLightOn();
        StopFog();
        StopRain();
        StopSnow();
    }

}
