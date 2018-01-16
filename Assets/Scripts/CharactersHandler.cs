using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharactersHandler : MonoBehaviour {

	public GameObject[] characters;
	public GameObject[] charactersDisabled;

	private GameObject[] allCharacters;
	// Use this for initialization
	void Start () {

		characters = GameObject.FindGameObjectsWithTag ("CharacterSelect");
		charactersDisabled = GameObject.FindGameObjectsWithTag ("CharacterSelectDisabled");

		allCharacters = characters.Concat(charactersDisabled).ToArray();

		foreach (GameObject character in allCharacters)
		{

			var button = character.GetComponent<Button> ();
			button.onClick.AddListener ( () => this.characterSelectClick(allCharacters, button) );

		}

	}

	// Update is called once per frame
	void Update () {

	}


	public void characterSelectClick(GameObject[] chars, Button clicked) {

//		Debug.Log (clicked.gameObject.tag);
// Debug.Log("character click");

		if (clicked.gameObject.tag == "CharacterSelect") {

			// Debug.Log ("selectable");

			if(clicked.GetComponent<CharacterSound>() != null) {
				clicked.GetComponent<CharacterSound>().PlayPrimary();
			} 

			var selectedOverlay = clicked.transform.Find ("SelectedOverlay");

			foreach (GameObject character in chars) {

				var button = character.GetComponent<Button> ();

				if (button.Equals (clicked)) {

					// Debug.Log ("clicked");

					selectedOverlay.gameObject.SetActive (true);

					var selectedText = clicked.transform.Find ("Text").GetComponent<Text> ().text;

					var panel_title = GameObject.FindGameObjectWithTag ("PanelTitleText").GetComponent<Text> ();

					panel_title.text = selectedText;

					var kart_image_name = selectedText.Replace (" ", "_") + "_selected";

					var kart_placeholder = GameObject.FindGameObjectWithTag ("CharacterSelectedPlaceholder").GetComponent<Image> ();

					kart_placeholder.sprite = Resources.Load<Sprite> (kart_image_name) as Sprite;




				} else {

					var unselectedOverlay = button.transform.Find ("SelectedOverlay");

					unselectedOverlay.gameObject.SetActive (false);



				}

			}

		} else {
			// Debug.Log("unselectable");
			if(clicked.GetComponent<CharacterSound>() != null) {
				clicked.GetComponent<CharacterSound>().PlaySecondary();
			}

		}

	}
}
