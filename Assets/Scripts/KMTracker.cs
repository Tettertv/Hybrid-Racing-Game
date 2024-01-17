using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KMTracker : MonoBehaviour
{
    private float textToShow;
    public Text text;
    public PlayerMovement player;
    public int StatToTrack;
    public GameHandler gameHandler;

    private float startTime;
    private float elapsedTime;

    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {

        if(StatToTrack == 1)
        {
            textToShow = (player.Velocity.z * 2);
            text.text = "KM/H = " + textToShow.ToString("#.#");
        }
        else if (StatToTrack == 2)
        {
            elapsedTime = Time.time - startTime;
            text.text = "Time Elapsed = " + elapsedTime.ToString("#.##");
            gameHandler.SetTimeElapsed(elapsedTime);
        } 
        else if(StatToTrack == 3)
        {
            text.text = "Distance Traveled = " + player.metersTraveled.ToString("#.");
            gameHandler.SetDistanceTraveled(player.metersTraveled);

        }
    }

    public void setText(string newText)
    {
        text.text = newText;
    }

}
