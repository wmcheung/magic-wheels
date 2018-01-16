using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	public GameObject CountDown;
	public AudioSource GetReady;
	public AudioSource GoAudio;

	public GameObject LapTimer;
	public GameObject CarControls;

	public AudioSource LevelMusic;


	// Use this for initialization
	void Start () {
		StartCoroutine (CountStart());
	}


	IEnumerator CountStart() {

		yield return new WaitForSeconds(1.5f);

		CountDown.GetComponent<Text>().text = "3";
		GetReady.Play();
		CountDown.SetActive(true);
		yield return new WaitForSeconds(1);
		CountDown.SetActive(false);

		CountDown.GetComponent<Text>().text = "2";
		GetReady.Play();
		CountDown.SetActive(true);
		yield return new WaitForSeconds(1);
		CountDown.SetActive(false);

		CountDown.GetComponent<Text>().text = "1";
		GetReady.Play();
		CountDown.SetActive(true);
		yield return new WaitForSeconds(1);
		CountDown.SetActive(false);

		CountDown.GetComponent<Text>().text = "GO";
		GoAudio.Play();
		CountDown.SetActive(true);

		if(LevelMusic) {
			LevelMusic.Play();
		}

		LapTimer.SetActive(true);
		CarControls.SetActive(true);

	}

}
