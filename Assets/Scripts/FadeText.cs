using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {

	private float transparancy = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(FadeTextToAlpha(1f, GetComponent<Text>()));
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator FadeTextToAlpha(float time, Text text) {
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
		while (text.color.a < transparancy)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
			yield return null;
		}
	}
}
