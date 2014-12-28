using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	//NavMeshAgents
	public NavMeshAgent agent;

	//transforms
	public Transform factory;

	//floats
	public float health;
	public float scoreValue;
	public float speed;
	public float chooseFactory;

	void Start ()
	{
		//the agent is the gameobjects navmeshagent
		agent = GetComponent<NavMeshAgent>();

		//generates a random number, used to choose a factory for the enemy to move towards
		chooseFactory = Random.Range (1,1);

		//using the random number the enemy chooses a factory to move towards
		if (chooseFactory == 1) 
		{
			factory = GameObject.FindGameObjectWithTag("Target1").transform;
		}
	}

	void Update () 
	{
		//sets the destination for the enemy
		agent.SetDestination(factory.position);

		//the speed float is used for the navmeshagent speed
		agent.speed = speed;

		//the enemy is destroyed if its health reaches below 1
		if (health < 1)
		{
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
