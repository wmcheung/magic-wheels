using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarProgress : MonoBehaviour {

	public int bars;

	public void buildProgressBar() {
		
		// var counter = 0;
		// var barsContainer = GameObject.FindGameObjectsWithTag ("BarProgress");
		var bar_1 = GameObject.Find ("Bar_1").GetComponent<Image>();
		var bar_2 = GameObject.Find ("Bar_2").GetComponent<Image>();
		var bar_3 = GameObject.Find ("Bar_3").GetComponent<Image>();


		switch (bars) {

		case 1:
			// Debug.Log (bars);
			bar_1.sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;
			bar_2.sprite = Resources.Load<Sprite> ("bar/item_bar_empty") as Sprite;
			bar_3.sprite = Resources.Load<Sprite> ("bar/item_bar_empty") as Sprite;

			break;

		case 2:
			// Debug.Log (bars);
			bar_1.sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;
			bar_2.sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;
			bar_3.sprite = Resources.Load<Sprite> ("bar/item_bar_empty") as Sprite;

			break;

		case 3:
			// Debug.Log (bars);
			bar_1.sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;
			bar_2.sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;
			bar_3.sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;

			break;

		default:
			break;


		}


//		foreach (GameObject fillable in barsContainer) {
//
//			counter++;
//			// second loop: increment to 2
//
//			//second loop: if counter is smaller than or equal to 2
//			if (counter <= bars) {
//				
//				//fillable is the object with the tag "BarProgress"
//				//get the component Image from it and set the sprite on it called "item_bar_normal"
//				fillable.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;
//
//			} else { 
//
//				fillable.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bar/item_bar_empty") as Sprite;
//
//			}
//		}
			
	}
}
