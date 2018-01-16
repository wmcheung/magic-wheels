using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCar01Track : MonoBehaviour {

	public GameObject TheMarker;

	public int objects;
	public GameObject Mark1;
	public GameObject Mark2;
	public GameObject Mark3;
	public GameObject Mark4;
	public GameObject Mark5;
	public GameObject Mark6;
	public GameObject Mark7;
	public GameObject Mark8;
	public GameObject Mark9;
	public GameObject Mark10;
	public GameObject Mark11;
	public GameObject Mark12;
	public GameObject Mark13;
	public GameObject Mark14;
	public GameObject Mark15;
	public GameObject Mark16;
	public GameObject Mark17;
	public GameObject Mark18;
	public GameObject Mark19;
	public GameObject Mark20;
	public GameObject Mark21;
	public GameObject Mark22;
	public GameObject Mark23;
	public GameObject Mark24;
	public GameObject Mark25;
	public GameObject Mark26;
	public GameObject Mark27;
	public GameObject Mark28;
	public GameObject Mark29;
	public GameObject Mark30;
	public GameObject Mark31;

	public int MarkTracker;

	// Update is called once per frame
	void Update () {

		// if(MarkTracker == 0) {
		// 	TheMarker.transform.position = Mark01.transform.position;
		// }

		switch(MarkTracker) {
			case 0:
				TheMarker.transform.position = Mark1.transform.position;
				TheMarker.transform.rotation = Mark1.transform.rotation;
				break;

			case 1:
				TheMarker.transform.position = Mark2.transform.position;
				TheMarker.transform.rotation = Mark2.transform.rotation;
				break;

			case 2:
				TheMarker.transform.position = Mark3.transform.position;
				TheMarker.transform.rotation = Mark3.transform.rotation;
				break;

			case 3:
				TheMarker.transform.position = Mark4.transform.position;
				TheMarker.transform.rotation = Mark4.transform.rotation;
				break;

			case 4:
				TheMarker.transform.position = Mark5.transform.position;
				TheMarker.transform.rotation = Mark5.transform.rotation;
				break;

			case 5:
				TheMarker.transform.position = Mark6.transform.position;
				TheMarker.transform.rotation = Mark6.transform.rotation;
				break;

			case 6:
				TheMarker.transform.position = Mark7.transform.position;
				TheMarker.transform.rotation = Mark7.transform.rotation;
				break;

			case 7:
				TheMarker.transform.position = Mark8.transform.position;
				TheMarker.transform.rotation = Mark8.transform.rotation;
				break;

			case 8:
				TheMarker.transform.position = Mark9.transform.position;
				TheMarker.transform.rotation = Mark9.transform.rotation;
				break;

			case 9:
				TheMarker.transform.position = Mark10.transform.position;
				TheMarker.transform.rotation = Mark10.transform.rotation;
				break;

			case 10:
				TheMarker.transform.position = Mark11.transform.position;
				TheMarker.transform.rotation = Mark11.transform.rotation;
				break;

			case 11:
				TheMarker.transform.position = Mark12.transform.position;
				TheMarker.transform.rotation = Mark12.transform.rotation;
				break;

			case 12:
				TheMarker.transform.position = Mark13.transform.position;
				TheMarker.transform.rotation = Mark13.transform.rotation;
				break;

			case 13:
				TheMarker.transform.position = Mark14.transform.position;
				TheMarker.transform.rotation = Mark14.transform.rotation;
				break;

			case 14:
				TheMarker.transform.position = Mark15.transform.position;
				TheMarker.transform.rotation = Mark15.transform.rotation;
				break;

			case 15:
				TheMarker.transform.position = Mark16.transform.position;
				TheMarker.transform.rotation = Mark16.transform.rotation;
				break;

			case 16:
				TheMarker.transform.position = Mark17.transform.position;
				TheMarker.transform.rotation = Mark17.transform.rotation;
				break;

			case 17:
				TheMarker.transform.position = Mark18.transform.position;
				TheMarker.transform.rotation = Mark18.transform.rotation;
				break;

			case 18:
				TheMarker.transform.position = Mark19.transform.position;
				TheMarker.transform.rotation = Mark19.transform.rotation;
				break;

			case 19:
				TheMarker.transform.position = Mark20.transform.position;
				TheMarker.transform.rotation = Mark20.transform.rotation;
				break;

			case 20:
				TheMarker.transform.position = Mark21.transform.position;
				TheMarker.transform.rotation = Mark21.transform.rotation;
				break;

			case 21:
				TheMarker.transform.position = Mark22.transform.position;
				TheMarker.transform.rotation = Mark22.transform.rotation;
				break;

			case 22:
				TheMarker.transform.position = Mark23.transform.position;
				TheMarker.transform.rotation = Mark23.transform.rotation;
				break;

			case 23:
				TheMarker.transform.position = Mark24.transform.position;
				TheMarker.transform.rotation = Mark24.transform.rotation;
				break;

			case 24:
				TheMarker.transform.position = Mark25.transform.position;
				TheMarker.transform.rotation = Mark25.transform.rotation;
				break;

			case 25:
				TheMarker.transform.position = Mark26.transform.position;
				TheMarker.transform.rotation = Mark26.transform.rotation;
				break;

			case 26:
				TheMarker.transform.position = Mark27.transform.position;
				TheMarker.transform.rotation = Mark27.transform.rotation;
				break;

			case 27:
				TheMarker.transform.position = Mark28.transform.position;
				TheMarker.transform.rotation = Mark28.transform.rotation;
				break;

			case 28:
				TheMarker.transform.position = Mark29.transform.position;
				TheMarker.transform.rotation = Mark29.transform.rotation;
				break;

			case 29:
				TheMarker.transform.position = Mark30.transform.position;
				TheMarker.transform.rotation = Mark30.transform.rotation;
				break;

			case 30:
				TheMarker.transform.position = Mark31.transform.position;
				TheMarker.transform.rotation = Mark31.transform.rotation;
				break;

			default:
				break;
		}

	}

	IEnumerator OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "ComputerCar01") {
			this.GetComponent<BoxCollider>().enabled = false;
			MarkTracker += 1;

			if(MarkTracker == 31) {
				MarkTracker = 0;
			}

			yield return new WaitForSeconds(1);
			this.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
