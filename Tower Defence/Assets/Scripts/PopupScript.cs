using UnityEngine;
using System.Collections;

public class PopupScript : MonoBehaviour {

	//gameObjects
	public GameObject Popup;

	//scripts
	public GameControlScript gameControlScript;

	void Start ()
	{
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}

	public void ClosePopup()
	{
		Popup.SetActive (false);
		gameControlScript.spawningAllowed = true;
	}
}
