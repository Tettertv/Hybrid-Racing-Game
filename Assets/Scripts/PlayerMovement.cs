using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rb;
    public ArduinoHandler arHandler;
    public Camera cam;
    public AudioClip carCrash;
    public AudioHandler audioHandler;

    public float arInput;
    public Vector3 Velocity;
    public float metersTraveled;

    [Header("FrontSpeed")]
    public float targetspeed;
    public float frontAccelAmount;
    public float frontDeccelAmount;

    [Header("SideSpeed")]
    public float maxSideSpeed;
    public float accelAmount;
    public float deccelAmount;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        metersTraveled = metersTraveled + ((Velocity.z * 2) * Time.deltaTime);
        CameraFOVChange();
        InputHandler();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void InputHandler()
    {
        arInput = arHandler.PotValue;
        Velocity = rb.velocity;
    }

    void Movement()
    {
		float sideTargetSpeed = arInput * maxSideSpeed;

        float accelRateSide;
        float accelRateFront;

        accelRateSide = (Mathf.Abs(sideTargetSpeed) > 0.01f) ? accelAmount : deccelAmount;
        accelRateFront = (Mathf.Abs(targetspeed) > 0.01f) ? frontAccelAmount : frontDeccelAmount;

        float speedDifSide = sideTargetSpeed - rb.velocity.x;
        float speedDifFront = targetspeed - rb.velocity.z;

        float movementSide = speedDifSide * accelRateSide;
        float movementFront = speedDifFront * accelRateFront;

        rb.AddForce(movementSide * Time.deltaTime, 0, movementFront * Time.deltaTime, ForceMode.Force);
	}

    public void SetTargetSpeed(float newTargetSpeed)
    {
        targetspeed = newTargetSpeed;
    }

    public void CameraFOVChange()
    {
        cam.fieldOfView = 70 + (Velocity.z / 2);
    }

    private void OnTriggerEnter(Collider collHit)
    {
        Destroy(collHit.gameObject);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z / 2);
        audioHandler.PlaySound(carCrash);
    }
}
