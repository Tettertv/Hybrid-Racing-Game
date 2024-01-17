using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    private Vector3 carLightRotation;

    public ArduinoHandler arHandler;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, arHandler.PotValue / 5 , 0);
    }
}
