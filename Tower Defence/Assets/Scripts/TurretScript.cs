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
	public float reloadTime;

	private float fireRate;

	void Update() 
	{
		//counter used to dictate the fire rate
		if(fireRate > 0)
		{
			fireRate -= 1;
		}

		//the turret will rotate toward the target 
		Vector3 targetPos = target.position - transform.position;
		float step = rotateSpeed * Time.deltaTime;
		Vector3 newPos = Vector3.RotateTowards(transform.forward, targetPos, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newPos);

		//the turret will shoot at the direction of the target, the reloadTime is used to determine the the rate of shots
		if (target.tag == "Enemy" && fireRate == 0)
		{
			fireRate += reloadTime;
			Instantiate(bullet, bulletPos.position, bulletPos.rotation);
		}
	}
	
	void OnTriggerStay(Collider obj)
	{
		//if the enemy comes into range, it is asigned as the target
		if (obj.gameObject.tag == "Enemy") 
		{
			target = obj.gameObject.transform;
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
}