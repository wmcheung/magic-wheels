using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelHandler : MonoBehaviour {

	private GameObject[] wheels;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void initListeners() {

		wheels = GameObject.FindGameObjectsWithTag ("WheelSelect");


		foreach (GameObject wheel in wheels)
		{

			var button = wheel.GetComponent<Button> ();
			button.onClick.AddListener ( () => this.GetComponent<OverviewComponent>().selectClick(wheels, button, true, true) );
		}

	}
}
