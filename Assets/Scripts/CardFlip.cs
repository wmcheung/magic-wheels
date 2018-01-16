using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardFlip : MonoBehaviour {

	// public Sprite front_image;

	public int fps = 60;
	public float rotateDegreePerSecond = 180;
	public bool isFaceUp = false;

	public ParticleSystem fireworkLeft;
	public ParticleSystem fireworkRight;

	float waitTime;
	bool isAnimationProcessing = false;
	bool changedImage = false;

	const float FLIP_LIMIT_DEGREE = 180f;

	public const string CARDFLIP_TAG = "CardImage";

	// Use this for initialization
	public void Start () {

		waitTime = 1.0f / fps;

		var card = GameObject.FindGameObjectWithTag (CARDFLIP_TAG);

		var button = card.GetComponent<Button> ();
		button.onClick.AddListener ( () => this.flipCard(card) );

		fireworkLeft.Stop ();
		fireworkRight.Stop ();

		flipCard(card);

	}

	// Update is called once per frame
	void Update () {


		if (isAnimationProcessing) {

			// Debug.Log (transform.eulerAngles.y);

			if (transform.eulerAngles.y > 89) {

				if (changedImage == false) {

					try {
						var cardface = transform.Find ("CardFace");
						cardface.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("cards/card_olaf_mirror") as Sprite;

						changedImage = true;

					} catch {
						// Debug.Log ("Error");
					}

					// Resources.Load<Sprite> ("bar/item_bar_normal") as Sprite;

					// Quaternion temp_rotation_y = 180;

					// cardface.rotation = Quaternion.Euler (0, 0, 0);

//					changedImage = true;
				}


			}

		}

	}

	public void flipCard(GameObject go) {
		Debug.Log("flipcard function called");

		if (isAnimationProcessing) {

			Debug.Log("return");

			return;

		} else {

			Debug.Log("flip function called");

			StartCoroutine (flip ());

		}

//		var img = go.GetComponent<CardFlip>().front_image;
//
//		go.transform.Find ("Image").GetComponent<Image> ().overrideSprite = img as Sprite;

//		Vector3 goToRight 	= new Vector3 (go.transform.position.x + 204, go.transform.position.y, go.transform.position.z);
//
//		// iTween.MoveTo (go, goToRight, 1);
//
//		iTween.RotateTo (this.gameObject, new Vector3(0, 200, 0), 2 );
//
//		Debug.Log ("ASDF");

	}

	IEnumerator flip() {

		Debug.Log("flipping");

		isAnimationProcessing = true;

		fireworkLeft.Play ();
		fireworkRight.Play ();

		bool done = false;

		while (!done) {

			float degree = rotateDegreePerSecond * Time.deltaTime;

			if (!isFaceUp) {

				degree = -degree;

			}

			transform.Rotate (new Vector3 (0, degree, 0));


			if (FLIP_LIMIT_DEGREE < transform.eulerAngles.y) {

				transform.Rotate (new Vector3 (0, -degree, 0));


				done = true;

			}


			yield return new WaitForSeconds (waitTime);

		}

		isFaceUp = !isFaceUp;
		isAnimationProcessing = false;

	}
}
