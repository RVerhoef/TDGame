using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour {

	//scripts
	public FactoryScript factoryScript;

	//texts
	public Text scoreText;

	//bools
	public bool spawningAllowed;

	//floats
	public float points;
	public float totalLives;
	public float totalMaxSpawns;
	public float currentWave;

	void Start () {

		//
		spawningAllowed = true;
		}
	
	void Update () {

		//each time the factory gameobject loses a life it is mirrored in this script
		factoryScript = GameObject.Find("Factory").GetComponent<FactoryScript>();
		totalLives = factoryScript.lives;

		//
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		scoreText.text = "Lives:" + totalLives +" Points:" + points +" Wave:" + currentWave;

		//
		if(totalMaxSpawns == 0 && GameObject.FindWithTag("Enemy") == null)
		{
			currentWave += 1;
			totalMaxSpawns = currentWave*5;
			spawningAllowed = false;
		}
	
	}
}
