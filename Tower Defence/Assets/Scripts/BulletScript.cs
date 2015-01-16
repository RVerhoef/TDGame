using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//scripts
	public GameControlScript gameControlScript;

	//floats
	public float speed;
	public float damage;

	void Start () 
	{
		//the bullet moves forward when spawned, using the speed float to determine how fast it should go, and the damage is upgraded if upgrades have been bought
		rigidbody.velocity = transform.forward * speed;
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
		damage = damage * gameControlScript.damageUpgrade;
	}
}
