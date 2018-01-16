using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWinpanelButton : MonoBehaviour {

	public GameObject overlay;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnCloseClick() {
		overlay.SetActive(false);
	}
}
