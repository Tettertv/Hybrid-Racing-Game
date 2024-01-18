using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ArduinoHandler : MonoBehaviour
{
    [Header("Components")]
    public PlayerMovement player;
    public EventsActivator eventHandler;
    //Serial port for Steering wheel
    private SerialPort streamA = new SerialPort("COM3", 9600);

    private string line = "";
    public bool canControl = true;
    public bool canControlCar = false;
    public int PotValue { get; private set; }
    public float sliderValue { get; private set; }

    public int buttonsValue { get; private set; }
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
        if (!canControlCar)
        {
            SteeringWheelTranslator();
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                PotValue = -100;
            } 
            else if (Input.GetKey(KeyCode.D))
            {
                PotValue = 100;
            }
            else
            {
                PotValue = 0;
            }
        }
        CheckSpeed();
    }

    private void FixedUpdate()
    {
        PanelTranslator();
        if (canControl)
        {
            ControllPanel();
        }
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

    private void PanelTranslator()
    {
        if (sliderValue <= 33f)
        {
            switch (buttonsValue)
            {
                case 2:
                    speedmode = "2";
                    break;
                case 11:
                    speedmode = "7";
                    break;
            }
            
        }
        else if (sliderValue >= 66f)
        {
            switch (buttonsValue)
            {
                case 1:
                    speedmode = "1";
                    break;
                case 8:
                    speedmode = "3";
                    break;
                case 10:
                    speedmode = "6";
                    break;
                case 5:
                    speedmode = "9";
                    break;
            }
        }
        else
        {
            switch (buttonsValue)
            {
                case 3:
                    speedmode = "5";
                    break;
                case 14:
                    speedmode = "9";
                    break;
                case 15:
                    speedmode = "4";
                    break;
            }
        }
    }

    private void CheckSpeed()
    {
        float sceneRightNow;
        sceneRightNow = SceneManager.GetActiveScene().buildIndex;
        if (sceneRightNow == 1)
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

                case "5":
                    eventHandler.LeftCarLightOn();
                    break;
                case "6":
                    eventHandler.RightCarLightOn();
                    break;

                case "7":
                    eventHandler.StopRain();
                    break;
                case "8":
                    eventHandler.StopFog();
                    break;
                case "9":
                    eventHandler.StopSnow();
                    break;

            }
        }
    }
    private void ControllPanel()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            speedmode = "1";
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            speedmode = "2";
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            speedmode = "3";
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            speedmode = "4";
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            speedmode = "5";
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            speedmode = "6";
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            speedmode = "7";
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            speedmode = "8";
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            speedmode = "9";
        }
    }
}