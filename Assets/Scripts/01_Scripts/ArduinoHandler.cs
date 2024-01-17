using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ArduinoHandler : MonoBehaviour
{
    [Header("Components")]
    public PlayerMovement player;
    //Serial port for Steering wheel
    private SerialPort streamA = new SerialPort("COM3", 9600);

    private string line = "";
    public int PotValue { get; private set; }
    public string speedmode = "1";

    Thread threadA;

    private void Start()
    {
        OpenThreadWheel();
    }

    private void OnDisable()
    {
        threadA.Abort();
        streamA.Close();
    }

    private void Update()
    {
        SteeringWheelTranslator();
        CheckSpeed();
    }

    private void OpenThreadWheel()
    {
        streamA.Open();
        streamA.ReadTimeout = 100;

        threadA = new Thread(new ThreadStart(ReadFromStream));
        threadA.Start();
    }

    private void SteeringWheelTranslator()
    {
        int PVal = 0;

        Int32.TryParse(line, out PVal);
        PotValue = PVal;
    }

    private void ReadFromStream()
    {
        while (threadA.IsAlive)
        {
            try
            {
                line = streamA.ReadLine();
            }
            catch (TimeoutException) { }
        }
    }

    private void CheckSpeed()
    {
        switch (speedmode)
        {
            case "1":
                player.SetTargetSpeed(25);
                break;
            case "2":
                player.SetTargetSpeed(40);
                break;
            case "3":
                player.SetTargetSpeed(50);
                break;
            case "4":
                player.SetTargetSpeed(60);
                break;

        }
    }
}