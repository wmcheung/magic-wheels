 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverviewComponent : MonoBehaviour {

	// private GameObject[] switchablePanels;

	public const string CHOOSEPOWER_TAG = "ChoosePower";
	private const string POWERUPSELECT_TAG = "PowerupSelect";
	private bool chosen1 = false;
	private bool chosen2 = false;

	private bool clicked;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void selectClick(GameObject[] items, Button clicked, bool useBarProgressClass, bool useTextClass, bool isPower = false) {

		var selectedOverlay = clicked.transform.Find ("SelectedOverlay");

		foreach (GameObject item in items) {

			var button = item.GetComponent<Button> ();

			if (button.Equals (clicked)) {

				selectedOverlay.gameObject.SetActive (true);
				clicked.transform.localScale = new Vector3(1.1F, 1.1F, 1.1F);

				if (isPower) { /** if button is a powerup **/

					var powerSelects = GameObject.FindGameObjectsWithTag (CHOOSEPOWER_TAG);
					var powerupButtons = GameObject.FindGameObjectsWithTag (POWERUPSELECT_TAG);
					var getPowerImage = clicked.transform.Find ("Icon").GetComponent<Image> ().sprite;

						if(powerSelects [0].name.Equals (clicked.name) || powerSelects[1].name.Equals(clicked.name)) {


						} else {

							if(chosen1 == true && chosen2 == true) {
								chosen1 = false;
								chosen2 = false;
							}

							if(chosen1 == true && chosen2 == false) {
								powerSelects[1].transform.Find ("Icon").GetComponent<Image> ().overrideSprite = getPowerImage;
								powerSelects[1].name = clicked.name;
								chosen2 = true;

							}

							if(chosen1 == false && chosen2 == false) {
								powerSelects[0].transform.Find ("Icon").GetComponent<Image> ().overrideSprite = getPowerImage;
								powerSelects[0].name = clicked.name;
								chosen1 = true;

							}

						}

				}

				if (useBarProgressClass) {

					clicked.GetComponent<BarProgress> ().buildProgressBar ();

				}

				if (useTextClass) {

					clicked.GetComponent<TextInformation> ().generateTextFromButton ();

				}

			} else {

				var unselectedOverlay = button.transform.Find ("SelectedOverlay");

				button.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
				unselectedOverlay.gameObject.SetActive (false);

			}

		}

	}


	public void playerClick(GameObject[] items, Button clicked) {

		foreach (GameObject item in items) {

			var button = item.GetComponent<Button> ();

			if (button.Equals (clicked)) {

				clicked.GetComponent<PlayerSelectorSwitcher> ().switcher (item);

			} else {

				//

			}

		}

	}

	public void choosePower(GameObject[] items, Button clicked) {

		// var selectedOverlay = clicked.transform.Find ("SelectedOverlay");

		// foreach (GameObject item in items) {
        //
		// 	var button = item.GetComponent<Button> ();
        //
		// 	if (button.Equals (clicked)) {
        //
		// 		selectedOverlay.gameObject.SetActive (true);
        //
		// 		// clicked.transform.localScale = new Vector3(1.1F, 1.1F, 1.1F);
        //
		// 	} else {
        //
		// 		var unselectedOverlay = button.transform.Find ("SelectedOverlay");
        //
		// 		// button.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
		// 		unselectedOverlay.gameObject.SetActive (false);
        //
		// 	}
        //
		// }

	}

}
