using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersSelectHandler : MonoBehaviour {

	private GameObject[] selectors;
	private bool alreadyInit = false;

	public GameObject addFriendPanel;


	// Use this for initialization
	void Start () {
		// this.initListeners ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initListeners() {

		if (!alreadyInit) {
			
			selectors = GameObject.FindGameObjectsWithTag ("PlayerSelectors");

			foreach (GameObject selector in selectors) {

				var button = selector.GetComponent<Button> ();
				button.onClick.AddListener (() => this.GetComponent<OverviewComponent> ().playerClick (selectors, button));

				var deleteButton = selector.transform.Find ("deleteButton").GetComponent<Button> ();
				deleteButton.onClick.AddListener (() => this.GetComponent<OverviewComponent> ().deletePlayerClick (selectors, button));
			}

			addFriendPanel = GameObject.FindGameObjectWithTag ("PlayerAddFriendPanel");

			addFriendPanel.SetActive (false);

			alreadyInit = true;

		}
	}
}
