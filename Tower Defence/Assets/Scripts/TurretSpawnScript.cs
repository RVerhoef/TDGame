using UnityEngine;
using System.Collections;

public class TurretSpawnScript : MonoBehaviour {

	//gameobjects
	public GameObject buyButton;
	public GameObject[] turretSpawner;

	//scripts
	public BuyButtonScript[] buyButtonScript;
	public GameControlScript gameControlScript;
	public TurretScript turretChild;
	
	void Start () 
	{
		//the script gets all the gameobjects with the buybutton tag and the gamecontrolscript, while also diabling the buybuttons
		turretSpawner = GameObject.FindGameObjectsWithTag ("TurretSpawner");
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
		buyButtonScript = new BuyButtonScript[turretSpawner.Length];

		//gets all the buybuttonscripts, they are used to assign the spawnpoint of the turret that is bought
		for (int i = 0; i < turretSpawner.Length; ++i)
			buyButtonScript[i] = turretSpawner[i].GetComponent<BuyButtonScript>();
	}

	//when the mouse is on this object and clicked, it is assigned as the spawnpoint for buybuttons
	void OnMouseOver () 
	{
		if(Input.GetMouseButtonDown(0) && gameControlScript.spawningAllowed == true)
		{
			if(gameObject.tag == "SpawnPoint" && gameControlScript.pointSelected == false)
			{
				for (int i = 0; i < turretSpawner.Length; ++i)
				buyButtonScript[i].spawnPoint = gameObject;
				buyButton.SetActive(true);
				gameControlScript.pointSelected = true;
				GetComponent<SpriteRenderer>().color = Color.gray;
			}
			//if the player already selected this object, the highlighting is removed as well as the buy menu, and it is no longer the target for spawning new turrets 
			else if(gameControlScript.pointSelected == true)
			{
				buyButton.SetActive(false);
				gameControlScript.pointSelected = false;
				GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}
}
