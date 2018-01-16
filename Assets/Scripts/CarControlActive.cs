using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarControlActive : MonoBehaviour {

	public GameObject CarControl;
	public GameObject ComputerCar01;

	// Use this for initialization
	void Start () {
		// CarControl.GetComponent<CarController>().enabled = true;
		CarControl.GetComponent<CarUserControl>().enabled = true;
		ComputerCar01.GetComponent<CarAIControl>().enabled = true;

	}

}
