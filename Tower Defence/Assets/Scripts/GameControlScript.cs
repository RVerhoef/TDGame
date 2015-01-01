using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	//gameobjects
	public FactoryScript factoryScript;

	//floats
	public float points;
	public float totalLives;
	
	void Update () {

		//each time the factory gameobject loses a life it is mirrored in this script
		factoryScript = GameObject.Find("Factory").GetComponent<FactoryScript>();
		totalLives = factoryScript.lives;
	
	}
}
