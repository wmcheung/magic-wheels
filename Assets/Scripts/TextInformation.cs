using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInformation : MonoBehaviour {

	public string textTitle;
	public string textDescription;

	public void generateTextFromButton() {

		var powerTitle 	= GameObject.Find ("PowerTitle").GetComponent<Text> ();
		var powerDesc 	= GameObject.Find ("PowerDescription").GetComponent<Text> ();

		powerTitle.text = textTitle;
		powerDesc.text 	= textDescription;

	}
}
