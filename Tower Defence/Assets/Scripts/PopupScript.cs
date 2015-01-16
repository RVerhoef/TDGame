using UnityEngine;
using System.Collections;

public class PopupScript : MonoBehaviour {

	//gameObjects
	public GameObject Popup;

	//scripts
	public GameControlScript gameControlScript;

	//gets the gameobjectscript
	void Start ()
	{
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}

	//when the popup is closed enemies will starts spawning again
	public void ClosePopup()
	{
		Popup.SetActive (false);
		gameControlScript.spawningAllowed = true;
	}
}
