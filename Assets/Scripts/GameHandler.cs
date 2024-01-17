using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;

    public float distanceTraveled;
    public float timeElapsedInGame;
    public EventsActivator eventHandler;

    public float distanceTarget;
    public float timeTarget;

    private bool isNextScene = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (!isNextScene)
        {
            if (timeElapsedInGame > timeTarget || distanceTraveled > distanceTarget)
            {
                NextScene();
            }
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isNextScene = true;
        StopAllCoroutines();
        Destroy(eventHandler);
    }

    public void SetTimeElapsed(float newTime)
    {
        timeElapsedInGame = newTime;
    }

    public void SetDistanceTraveled(float newDistance)
    {
        distanceTraveled = newDistance;
    }
}
