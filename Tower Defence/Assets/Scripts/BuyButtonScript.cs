using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour {

	//scripts
	public GameControlScript gameControlScript;

	//gameobject
	public GameObject turret;
	public GameObject spawnPoint;

	//floats
	public float cost;

	//the spawnturret function is called when a button is pressed, the function instantiates a turret as a child of the clicked spawnpoint
	public void SpawnTurret () 
	{
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
		if(gameControlScript.points >= cost)
		{
			gameControlScript.points -= cost;	
			spawnPoint.tag = "TurretPoint";
			GameObject turretCopy = Instantiate (turret, spawnPoint.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
			turretCopy.transform.parent = spawnPoint.transform;
			spawnPoint = null;
		}

	}
}
