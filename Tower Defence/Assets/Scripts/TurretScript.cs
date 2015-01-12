using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	//transforms
	public Transform target;
	public Transform bulletPos;

	//Gameobjects
	public GameObject bullet;

	//floats
	public float rotateSpeed;
	public float fireRate;
	public float reload;

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
		Invoke ("Shoot", fireRate);
	}

	void Shoot ()
	{
		if(Time.time >= reload + 1)
		{
		Instantiate(bullet, bulletPos.position, bulletPos.rotation);
		reload = Time.time;
		}
	}
}