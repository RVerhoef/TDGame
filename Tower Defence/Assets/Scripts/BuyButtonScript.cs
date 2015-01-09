using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour {

	//gameobject
	public GameObject turret;
	public GameObject spawnPoint;

	public void SpawnTurret () 
	{
		Instantiate (turret, spawnPoint.transform.position, Quaternion.Euler(0,0,0));
	}
}
