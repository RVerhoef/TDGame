using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	//gameobjects
	public GameObject enemy;

	//scripts
	public GameControlScript gameControlScript;

	//floats
	public float startTime;
	public float repeatTime;

	void Start () 
	{
		//finds the gamecontrol object and the gamecontrolscript
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();

		//an enemy is spawned as soon as the startTime is over, and keep spawning every time the repeatTime is over
			InvokeRepeating ("Spawn", startTime, repeatTime);
	}

	void Spawn ()
	{
		//spawns the enemy at the position of this gameobject if spawning is allowed
		if (gameControlScript.spawningAllowed == true && gameControlScript.totalMaxSpawns > 0) 
		{
			Instantiate (enemy, this.transform.position, this.transform.rotation);
			gameControlScript.totalMaxSpawns -= 1;
		}
	}
}
