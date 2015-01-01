using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	//GameObjects
	public GameObject enemy;

	//bools
	public bool spawning;

	//floats
	public float startTime;
	public float repeatTime;

	void Start () 
	{
		//an enemy is spawned as soon as the startTime is over, and keep spawning every time the repeatTime is over
			InvokeRepeating ("Spawn", startTime, repeatTime);
	}

	void Spawn ()
	{
		//spawns the enemy at the position of this gameobject
		Instantiate (enemy, this.transform.position, this.transform.rotation);
	}
}
