﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

	public GameObject LapCompleteTrigger;
	public GameObject HalfLapTrigger;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public GameObject LapTimeBox;
	public GameObject LapCounter;
	public int LapsDone;
	public float RawTime;

	public GameObject RaceFinish;

	void Update() {
		if(LapsDone == 1) {
			RaceFinish.SetActive (true);
		}
	}

	void OnTriggerEnter() {

		if(LapsDone != 1) {
			LapsDone += 1;
		}

		RawTime = PlayerPrefs.GetFloat("RawTime");

		if(LapTimeManager.RawTime <= RawTime) {
			if(LapTimeManager.SecondCount <= 9) {
				SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
			} else {
				SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
			}

			if(LapTimeManager.MinuteCount <= 9) {
				MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
			} else {
				MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
			}

			MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;
		}

		PlayerPrefs.SetInt ("MinSave", LapTimeManager.MinuteCount);
		PlayerPrefs.SetInt ("SecSave", LapTimeManager.SecondCount);
		PlayerPrefs.SetFloat ("MilliSave", LapTimeManager.MilliCount);
		PlayerPrefs.SetFloat ("RawTime", LapTimeManager.RawTime);

		LapTimeManager.MinuteCount = 00;
		LapTimeManager.SecondCount = 00;
		LapTimeManager.MilliCount = 00;
		LapTimeManager.RawTime = 0;

		LapCounter.GetComponent<Text>().text = "" + LapsDone;

		HalfLapTrigger.SetActive(true);
		LapCompleteTrigger.SetActive(false);

	}


}
