using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineHandler : MonoBehaviour {

	private GameObject[] engines;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void initListeners() {

		engines = GameObject.FindGameObjectsWithTag ("EngineSelect");


		foreach (GameObject engine in engines)
		{

			var button = engine.GetComponent<Button> ();
			button.onClick.AddListener ( () => this.GetComponent<OverviewComponent>().selectClick(engines, button, true, true) );

		}

	}
}
