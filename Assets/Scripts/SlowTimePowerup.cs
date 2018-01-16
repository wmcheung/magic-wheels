using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class SlowTimePowerup : MonoBehaviour {

	public static float SlowTimeScale = 0.5f;
	public static float NormalTimeScale = 1f;
	public static float TimeOut = 2.5f;
	public GameObject OtherCar;
	public GameObject PowerUpButton;
	private Rigidbody OtherCarRigidBody;
	public GameObject Overlay;
	public GameObject _Camera;

	void Start() {
		// AICars = GameObject.FindGameObjectsWithTag("ComputerCar01");
		OtherCarRigidBody = OtherCar.GetComponent<Rigidbody>();
		Overlay.SetActive(false);
		Overlay.GetComponent<CanvasRenderer>().SetAlpha(0.0f);

	}

	public void SlowTime() {

		if(OtherCar.tag == "ComputerCar01") {
			StartCoroutine(SlowDown());
		}
	}

	public void CoolDownHandler() {
		if(PowerUpButton.activeSelf == false ) {
			PowerUpButton.SetActive(true);
		} else {
			PowerUpButton.SetActive(false);
		}
	}

	public IEnumerator CoolDown() {
		PowerUpButton.SetActive(false);

		yield return new WaitForSeconds(TimeOut);

		PowerUpButton.SetActive(true);

	}

	public IEnumerator SlowDown() {
		// Debug.Log("Slow Down Powerup");
		PowerUpButton.GetComponent<Button>().interactable = false;
		Overlay.SetActive(true);
		Overlay.GetComponent<Image>().CrossFadeAlpha(0.1f, TimeOut - 1.0f , false);

		Time.timeScale = SlowTimeScale;

		_Camera.GetComponent<FrostEffect>().enabled = true;

		yield return new WaitForSeconds(TimeOut);
		// Debug.Log("Slow Down Powerup reactivate");
		PowerUpButton.GetComponent<Button>().interactable = true;
		Time.timeScale = NormalTimeScale;
		Overlay.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
		Overlay.GetComponent<Image>().CrossFadeAlpha(0.0f, 1.0f, false);
		yield return new WaitForSeconds(1.0f);
		Overlay.SetActive(false);
		Overlay.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		_Camera.GetComponent<FrostEffect>().enabled = false;


	}

	public void SlowDownHandler(float _Time) {

		float delta = Time.fixedDeltaTime * _Time;
		OtherCar.GetComponent<Rigidbody>().velocity += Physics.gravity / OtherCarRigidBody.mass * delta;

		// delta = Time.fixedDeltaTime;
		// OtherCarRigidBody.velocity = Physics.gravity / OtherCarRigidBody.mass * delta;
	}

	public IEnumerator CountDown() {
		// Time.timeScale = SlowTimeScale;
		// HandleActive();
		yield return new WaitForSeconds(TimeOut);
		// Time.timeScale = NormalTimeScale;
		// HandleActive();
		// OtherCar.GetComponent<CarController>().enabled = false;

	}
}
