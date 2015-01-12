using UnityEngine;
using System.Collections;

public class TurretSpawnScript : MonoBehaviour {

	//gameobjects
	public GameObject buyButton;

	//scripts
	public BuyButtonScript buyButtonScript;
	
	void Start () 
	{
		//the script gets all the gameobjects with the buybutton tag and the gamecontrolscript, while also diabling the buybuttons
		buyButtonScript = GameObject.FindGameObjectWithTag("TurretSpawner").GetComponent<BuyButtonScript>();
		buyButton = GameObject.FindGameObjectWithTag("BuyButton");
	}

	//when the mouse is on this object and clicked, it is assigned as the spawnpoint for buybuttons
	void OnMouseOver () 
	{
		if(Input.GetMouseButtonDown(0) && gameObject.tag == "SpawnPoint")
		{
			buyButtonScript.spawnPoint = gameObject;
		}
	}
}
