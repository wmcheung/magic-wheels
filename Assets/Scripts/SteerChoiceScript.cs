using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerChoiceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void JoystickChoice() {
		PlayerPrefs.SetString("Controls", "Joystick");
	}

	public void AcceleroChoice() {
		PlayerPrefs.SetString("Controls", "Accelerometer");
	}
}
