using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHandler : MonoBehaviour {

	private GameObject[] powerups;
	private GameObject[] choose_powers;

	public const string CHOOSEPOWER_TAG = "ChoosePower"; //plus icon button
	public const string POWERUPSELECT_TAG = "PowerupSelect"; //actual powerup

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void initListeners() {

		powerups = GameObject.FindGameObjectsWithTag (POWERUPSELECT_TAG); /** POWERUP BUTTON **/
		choose_powers = GameObject.FindGameObjectsWithTag (CHOOSEPOWER_TAG); /** PLUS ICON BUTTON **/

		foreach (GameObject wheel in powerups)
		{

			var button = wheel.GetComponent<Button> ();
			button.onClick.AddListener ( () => this.GetComponent<OverviewComponent>().selectClick(powerups, button, false, true, true) );

		}


		// foreach (GameObject item in choose_powers)
		// {

			// var button = item.GetComponent<Button> ();
			// button.onClick.AddListener ( () => this.GetComponent<OverviewComponent>().choosePower(choose_powers, button) );

		// }

	}
}
