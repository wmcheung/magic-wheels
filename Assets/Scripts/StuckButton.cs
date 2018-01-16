using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckButton : MonoBehaviour {

	public Transform[] safePoints;
	// private float _originalRotX;
	// private float _originalRotZ;

	// Use this for initialization
	void Start () {
		// _originalRotX = transform.rotation.x;
        // _originalRotZ = transform.rotation.z;
	}


	// Update is called once per frame
	void Update () {

	}


	public void resetCar() {
		Transform closestTransform;
		float closestDistance = 99999;
		Vector3 currentPos = transform.position;

		foreach(Transform trans in safePoints) {
			float currentDistance = Vector3.Distance(currentPos, trans.position);

			if(currentDistance < closestDistance)
			{
				closestDistance = currentDistance;
				closestTransform = trans;
			}
		}

		// transform.position = closestTransform.position;
		// transform.rotation = closestTransform.rotation;
	}
}
