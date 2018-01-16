using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class RaceFinish : MonoBehaviour {

	public GameObject TheCar;
	public GameObject FinishCam;
	public GameObject ViewModes;
	public GameObject LevelMusic;
	public GameObject AICar;
	public GameObject Overlay;

	void OnTriggerEnter() {

		Overlay.SetActive(true);
		// TheCar.SetActive (false);
		// CarController.m_Topspeed = 0.0f;
		CarUserControl.forward = 0.0f;
		// TheCar.GetComponent<CarController>().enabled = false;
		// TheCar.GetComponent<CarUserControl>().enabled = false;
		LevelMusic.GetComponent<AudioSource>().volume = 0;

		// TheCar.SetActive (true);
		FinishCam.SetActive(true);
		// LevelMusic.SetActive(false);
		ViewModes.SetActive(false);
		TheCar.GetComponent<CarAudio>().StopSound();
		TheCar.GetComponent<CarAudio>().enabled = false;
		AICar.GetComponent<CarAudio>().StopSound();
		AICar.GetComponent<CarAudio>().enabled = false;

	}

}
