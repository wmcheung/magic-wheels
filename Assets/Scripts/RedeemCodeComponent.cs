using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedeemCodeComponent : MonoBehaviour {

	public InputField codeField;
	public GameObject canvas;


	private string CodeField;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CodeClick() {

		var mainPanel = canvas.transform.Find("MainPanel");
		var redeemPanel = canvas.transform.Find("RedeemPanel");
		var redeemCardPanel = canvas.transform.Find("RedeemCardPanel");

		CodeField = codeField.text;

		switch (CodeField) {

		case "9125":

			mainPanel.gameObject.SetActive (false);
			redeemPanel.gameObject.SetActive (false);
			redeemCardPanel.gameObject.SetActive (true);

			redeemCardPanel.transform.Find ("Button").GetComponent<CardFlip> ().Start ();


			var characterHandlerComponent = GameObject.Find ("GameObject").GetComponent<CharactersHandler> ();
			var charactersDisabled = characterHandlerComponent.charactersDisabled;
		
			foreach (GameObject character in charactersDisabled)
			{

				if (character.name == "CharacterButtonOlaf") {

					character.tag = "CharacterSelect";

					// character.transform.Find ("DisabledOverlay").GetComponent<GameObject> ().SetActive (false);

					character.transform.Find ("DisabledOverlay").gameObject.SetActive (false);
				}
					
			}


			break;

		}
			
	}
		
}
