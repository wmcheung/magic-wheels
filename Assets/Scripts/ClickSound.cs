using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickSound : MonoBehaviour {

	public AudioSource _Sound;

	public void PlaySound() {
		_Sound.Play();
	}
}
