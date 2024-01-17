using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisplay : MonoBehaviour
{
	public int displayID;

	void Awake()
	{
		GetComponent<Camera>().targetDisplay = displayID;
	}
}
