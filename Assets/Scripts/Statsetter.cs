using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statsetter : MonoBehaviour
{
    private GameHandler gamehandler;
    public KMTracker timeTrack;
    public KMTracker disTrack;
    void Start()
    {
        gamehandler = FindObjectOfType<GameHandler>();
        timeTrack.setText("Time Elapsed = " + gamehandler.timeElapsedInGame.ToString("#.##") + " Seconds");
        disTrack.setText("Distance Traveled = " + gamehandler.distanceTraveled.ToString("#.") + " Meters");
    }


}
