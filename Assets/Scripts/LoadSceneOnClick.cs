using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByStringAdditive(string sceneName) {

		Debug.Log ("Loaded Redeem Screen");

		SceneManager.LoadScene ("RedeemCode", LoadSceneMode.Additive);

	}

	public void LoadByStringSingle(string sceneName) {

		Debug.Log ("Loaded Play Screen");

		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);

	}
}
