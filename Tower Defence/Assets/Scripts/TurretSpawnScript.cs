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

	//
	void OnMouseOver () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			buyButtonScript.spawnPoint = gameObject;
		}
	}
}
