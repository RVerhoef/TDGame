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

		for (int i = 0; i < turretSpawner.Length; ++i )
			buyButtonScript[i] = turretSpawner[i].GetComponent<BuyButtonScript>();
	}

	void Update ()
	{

	}

	//when the mouse is on this object and clicked, it is assigned as the spawnpoint for buybuttons
	void OnMouseOver () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(gameObject.tag == "SpawnPoint" && gameControlScript.pointSelected == false)
			{
				for (int i = 0; i < turretSpawner.Length; ++i )
				buyButtonScript[i].spawnPoint = gameObject;
				buyButton.SetActive(true);
				gameControlScript.pointSelected = true;
				GetComponent<SpriteRenderer>().color = Color.gray;
			}

			else if(gameControlScript.pointSelected == true)
			{
				buyButton.SetActive(false);
				gameControlScript.pointSelected = false;
				GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}
}
