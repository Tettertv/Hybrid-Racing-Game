using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class NathanArduinoHandlerFix : MonoBehaviour
{
    private SerialPort stream = new SerialPort("COM7", 9600);

    Dictionary<string, int> hardwareVars = new Dictionary<string, int>();
    private string line = "";

    public int SteeringWheelValue { get; private set; }
    public int ButtonCombinationValue { get; private set; }
    public int SliderValue { get; private set; }
    public int ConfirmButtonValue { get; private set; }

    public UnityEvent OnButtonPressed;

    Thread thread;

    private void Start()
    {
        stream.Open();
        stream.ReadTimeout = 100;

        thread = new Thread(new ThreadStart(ReadFromStream));
        thread.Start();

        SteeringWheelValue = 0;
        ButtonCombinationValue = 0;
        SliderValue = 0;
        ConfirmButtonValue = 0;
    }

    private void OnDisable()
    {
        thread.Abort();
        stream.Close();
    }

    private void Update()
    {
        if (hardwareVars.ContainsKey("steeringWheel"))
        {
            SteeringWheelValue = hardwareVars["steeringWheel"];
        }
        if (hardwareVars.ContainsKey("buttonCombination"))
        {
            ButtonCombinationValue = hardwareVars["buttonCombination"];
        }
        if (hardwareVars.ContainsKey("slider"))
        {
            SliderValue = hardwareVars["slider"];
        }
        if (hardwareVars.ContainsKey("buttonConfirm"))
        {
            ConfirmButtonValue = hardwareVars["buttonConfirm"];
        }

        if (ConfirmButtonValue == 1)
        {
            OnButtonPressed.Invoke();
        }

        //Debug.Log("SunPotValue : " + SunPotValue + "buttun state : " + hardwareVars["button"]);
        Debug.Log("steeringwheel : " + SteeringWheelValue + " | ButtonCombination : " + ButtonCombinationValue + " | Slider : " + SliderValue + " | ConfirmButtonValue : " + ConfirmButtonValue);
    }

    private void ReadFromStream()
    {
        // Splits read data and saves it in the corresponding properties
        while (thread.IsAlive)
        {
            try
            {
                line = stream.ReadLine();
            }
            catch (TimeoutException) { }
            //Debug.Log(line);

            string[] parts = line.Split(",");

            foreach (string part in parts)
            {
                //Debug.Log(part);
                string[] keyValue = part.Split(":");
                string key = keyValue[0];
                int value = int.Parse(keyValue[1]);

                hardwareVars[key] = value;
                //Debug.Log(hardwareVars[key]);
            }

            //if (hardwareVars["button"] == 0)
            //{
            //    ButtonPressed = true;
            //}
            //else
            //{
            //    ButtonPressed = false;
            //}
        }
    }
}

