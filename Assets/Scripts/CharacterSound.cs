using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSound : MonoBehaviour {

	public AudioSource PrimarySound; //select
	public AudioSource SecondarySound; //unavailable

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void PlayPrimary() {
		PrimarySound.Play();
	}

	public void PlaySecondary() {
		SecondarySound.Play();
	}
}
