using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour {

	//scripts
	public GameControlScript gameControlScript;

	//audio
	public AudioClip canBuy;
	public AudioClip cantBuy;

	//gameobject
	public GameObject turret;
	public GameObject spawnPoint;
	public GameObject buyButton;

	//floats
	public float cost;

	//the spawnturret function is called when a button is pressed, the function instantiates a turret as a child of the clicked spawnpoint if the player has enough points, plays sounds and puts the highlighting to off
	public void SpawnTurret () 
	{
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();

		if(gameControlScript.points >= cost)
		{
			audio.PlayOneShot(canBuy);
			gameControlScript.points -= cost;	
			GameObject turretCopy = Instantiate (turret, spawnPoint.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
			turretCopy.transform.parent = spawnPoint.transform;
			spawnPoint.tag = "TurretPoint";
			buyButton.SetActive(false);
			spawnPoint.GetComponent<SpriteRenderer>().color = Color.white;
			gameControlScript.pointSelected = false;
		}
		//if the player doesnt have enough points a sound will be played
		else
		{
			audio.PlayOneShot(cantBuy);
		}

	}
}
