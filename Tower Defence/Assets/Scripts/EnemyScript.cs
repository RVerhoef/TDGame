using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	//NavMeshAgents
	public NavMeshAgent agent;

	//transforms
	public Transform factory;

	//scripts
	public GameControlScript gameControlScript;

	//floats
	public float health;
	public float pointValue;
	public float speed;

	void Start ()
	{
		//find the gamecontrol object and the gamecontrolscript
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();

		//the agent is the gameobjects navmeshagent
		agent = GetComponent<NavMeshAgent>();

		//finds the target that the enemy will move towards
		factory = GameObject.FindGameObjectWithTag("Factory").transform;

		//health of the enemy gets higher as the waves gets higher
		health = health * gameControlScript.currentWave /2;

		//speed of the enemy gets higher if the waves get higher
		speed = speed * gameControlScript.currentWave /2;
	}

	void Update () 
	{
		//sets the destination for the enemy
		agent.SetDestination(factory.position);

		//the speed float is used for the navmeshagent speed
		agent.speed = speed;

		//the enemy is destroyed if its health reaches below 1, and the points are added to the GameControl object
		if (health < 1)
		{
			pointValue = gameControlScript.totalLives / 10;
			gameControlScript.points += pointValue;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider obj)
	{
		//if the enemy comes into range, it is asigned as the target
		if (obj.gameObject.tag == "Bullet") 
		{
			//the enemy gets the damage value from the bullet hitting him, substracts the value from its health and destroys the bullet
			BulletScript bulletDamage = obj.gameObject.GetComponent<BulletScript>();
			health -= bulletDamage.damage;
			Destroy(obj.gameObject);
		}
	}
}
