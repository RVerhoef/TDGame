using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	//gameobjects
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

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
		//spawns the enemy at the position of this gameobject if spawning is allowed, used the spawnenemy value to choose which enemy type to spawn
		if (gameControlScript.spawningAllowed == true && gameControlScript.totalMaxSpawns > 0) 
		{
			if(gameControlScript.spawnEnemy == 0)
			{
				Instantiate (enemy1, this.transform.position, this.transform.rotation);
				gameControlScript.totalMaxSpawns -= 1;
			}
			else if(gameControlScript.spawnEnemy == 1)
			{
				Instantiate (enemy2, this.transform.position, this.transform.rotation);
				gameControlScript.totalMaxSpawns -= 1;
			}
			else if(gameControlScript.spawnEnemy == 2)
			{
				Instantiate (enemy3, this.transform.position, this.transform.rotation);
				gameControlScript.totalMaxSpawns -= 1;
			}
		}
	}
}
