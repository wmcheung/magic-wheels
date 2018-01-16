using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapHandler : MonoBehaviour {

	public GameObject[] maps;
	private GameObject random;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void initListeners() {

		maps = GameObject.FindGameObjectsWithTag ("MapSelect");
		random = GameObject.FindGameObjectWithTag ("MapSelectRandom");

		var randomButton = random.GetComponent<Button> ();
		randomButton.onClick.AddListener ( () => this.randomMapSelect(maps) );

		foreach (GameObject map in maps)
		{

			var button = map.GetComponent<Button> ();
			button.onClick.AddListener ( () => this.mapSelectClick(maps, button) );

		}

	}
		
	void randomMapSelect(GameObject[] maps) {

		var index = Random.Range (0, maps.Length);

		var currentPoint = maps [index];

		var selectedText = currentPoint.transform.Find("Text").GetComponent<Text>().text;

		var panel_title = GameObject.FindGameObjectWithTag ("PanelTitleText").GetComponent<Text>();

		panel_title.text = "World: " + selectedText;

		string map_image_name = selectedText.Replace (" ", "_").ToLower();

		var map_placeholder = GameObject.FindGameObjectWithTag ("MapSelectedPlaceholder").GetComponent<Image> ();		

		map_placeholder.sprite = Resources.Load<Sprite> ("world/world_large_" + map_image_name) as Sprite;

		// Debug.Log (currentPoint.GetComponent<Image>().sprite);

		var selectedOverlay = currentPoint.transform.Find ("SelectedOverlay");

		foreach (GameObject map in maps) {

			if (map.Equals (currentPoint)) {

				selectedOverlay.gameObject.SetActive (true);

			} else {
				
				var unselectedOverlay = map.transform.Find ("SelectedOverlay");
	
				unselectedOverlay.gameObject.SetActive (false);

			}

		}
	}


	void mapSelectClick(GameObject[] maps, Button clicked) {

		var selectedOverlay = clicked.transform.Find ("SelectedOverlay");

		foreach (GameObject map in maps) {

			var button = map.GetComponent<Button> ();

			if (button.Equals (clicked)) {

				selectedOverlay.gameObject.SetActive (true);

				var selectedText = clicked.transform.Find ("Text").GetComponent<Text>().text;

				var panel_title = GameObject.FindGameObjectWithTag ("PanelTitleText").GetComponent<Text>();

				panel_title.text = "World: " + selectedText;

				string map_image_name = selectedText.Replace (" ", "_").ToLower();

				var map_placeholder = GameObject.FindGameObjectWithTag ("MapSelectedPlaceholder").GetComponent<Image> ();		

				map_placeholder.sprite = Resources.Load<Sprite> ("world/world_large_" + map_image_name) as Sprite;

			} else {

				var unselectedOverlay = button.transform.Find ("SelectedOverlay");

				unselectedOverlay.gameObject.SetActive (false);

			}

		}

	}
}
