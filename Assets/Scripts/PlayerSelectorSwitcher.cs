using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectorSwitcher : MonoBehaviour {

	public string state;

	[HideInInspector]
	public float defaultX;
	private bool firstTimeClicked = false;
	private string[] states = {"computer", "player", "addPlayer"};
	private string[] statesPlaceholder = {"computer", "vriend", "speler toevoegen +"};

	public void switcher(GameObject selected, GameObject addFriendPanel) {
		
		var switch_go = selected.transform.Find ("switcher").gameObject;

		var switch_obj = selected.transform.Find ("switcher").GetComponent<Transform>();
		var switch_obj_text = switch_obj.transform.Find ("switcherText").GetComponent<Text>();

		if (!firstTimeClicked) {

			defaultX = switch_obj.transform.position.x;
			firstTimeClicked = true;
			
		}

		// Debug.Log (switch_obj.transform.position.x);
		// Debug.Log (selected.transform.position.x);


		switch (state) {
			
		case "computer":
				
			Debug.Log ("computer");	
				
			var selectedWidth = selected.GetComponent<RectTransform> ().rect.width;
			var switchWidth = switch_obj.GetComponent<RectTransform> ().rect.width;
			var switchPostionX = switch_obj.position.x;

			Vector3 goToRight = new Vector3 ((switch_obj.position.x + switchWidth) - 20, switch_obj.position.y, switch_obj.position.z);

			iTween.MoveTo (switch_go, goToRight, 1);

			state = states [1];
			switch_obj_text.text = statesPlaceholder [1];

			addFriendPanel.SetActive (true);

			break;

		case "player":
			
			Debug.Log ("player");	
			
			Vector3 goToLeft 	= new Vector3 (defaultX, switch_obj.position.y, switch_obj.position.z);

			iTween.MoveTo (switch_go, goToLeft, 1);

			state = states [0];
			switch_obj_text.text = statesPlaceholder [0];

			break;
		
		case "addPlayer":

			Debug.Log ("adding player");

			state = states [0];
				
			//kart_placeholder.sprite = Resources.Load<Sprite> (kart_image_name) as Sprite;
			selected.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("choose_players/player_busy_selecting") as Sprite;

			selected.transform.Find ("friend").gameObject.SetActive (true);
			selected.transform.Find ("computer").gameObject.SetActive (true);
			selected.transform.Find ("switcher").gameObject.SetActive (true);
			selected.transform.Find ("deleteButton").gameObject.SetActive (true);

			selected.transform.Find ("addPlayerText").gameObject.SetActive (false);


			break;

		}


		// switch_obj.transform.position = goToRight;

	}

	public void deleteSwitcher(GameObject selected) {

		Debug.Log ("removing player");

		state = states [2];

		var switch_go = selected.transform.Find ("switcher").gameObject;
		var switch_obj = selected.transform.Find ("switcher").GetComponent<Transform>();
		var switch_obj_text = switch_obj.transform.Find ("switcherText").GetComponent<Text>();

		Vector3 goToLeft 	= new Vector3 (defaultX, switch_obj.position.y, switch_obj.position.z);

		iTween.MoveTo (switch_go, goToLeft, 1);
		switch_obj_text.text = statesPlaceholder [0];

		selected.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("choose_players/player_unselected") as Sprite;

		selected.transform.Find ("friend").gameObject.SetActive (false);
		selected.transform.Find ("computer").gameObject.SetActive (false);
		selected.transform.Find ("switcher").gameObject.SetActive (false);
		selected.transform.Find ("deleteButton").gameObject.SetActive (false);

		selected.transform.Find ("addPlayerText").gameObject.SetActive (true);

	}
}
