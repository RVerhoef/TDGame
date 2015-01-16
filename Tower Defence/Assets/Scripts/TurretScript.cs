using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	//bool

	//scripts
	public GameControlScript gameControlScript;

	//colliders
	public SphereCollider collider;

	//audio
	public AudioClip shoot;

	//transforms
	private Transform target;
	public Transform bulletPos;

	//Gameobjects
	public GameObject bullet;

	//floats
	public float rotateSpeed;
	public float fireRate;
	public float maxFireRate;
	public float maxRadius;

	void Start()
	{
		//the turret will start to shoot
		InvokeRepeating ("Shoot", fireRate, fireRate);
		//get the collider of the turret
		collider = transform.GetComponent<SphereCollider>();
		//find the gamecontrol script
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}

	void Update()
	{
		//upgrades the firerate, currently bugged
		if(fireRate > fireRate / gameControlScript.firerateUpgrade && fireRate > maxFireRate)
		{
			fireRate = fireRate *= gameControlScript.firerateUpgrade;
		}
		//upgrades the max range of the turret
		if(collider.radius < collider.radius * gameControlScript.rangeUpgrade && collider.radius < maxRadius)
		{
			collider.radius *= gameControlScript.rangeUpgrade;
		}
	}

	//if an enemy et in range, it is assinged as the target of the turret
	void OnTriggerStay(Collider obj)
	{
		//if the enemy comes into range, it is asigned as the target
		if (obj.gameObject.tag == "Enemy") 
		{
			target = obj.gameObject.transform;
			Invoke("Targeting", 0);
		}
	}

	void OnTriggerExit(Collider obj)
	{
		//if the enemy moves out of range, the target is returned to null
		if (obj.gameObject.tag == "Enemy") 
		{
			target = null;
		}
	}

	void Targeting() 
	{
		//the turret will rotate toward the target 
		Vector3 targetPos = target.position - transform.position;
		float step = rotateSpeed * Time.deltaTime;
		Vector3 newPos = Vector3.RotateTowards(transform.forward, targetPos, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newPos);
	}

	void Shoot ()
	{
		//the enemy will shoot if the target is an enemy, it shoots by instantiating a bullet and playing a sound
		if(target.tag == "Enemy")
		{
		Instantiate(bullet, bulletPos.position, bulletPos.rotation);
		audio.PlayOneShot(shoot);
		}
	}
}