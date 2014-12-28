using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//floats
	public float speed;
	public float damage;

	void Start () 
	{
		//the bullet moves forward when spawned, using the speed float to determine how fast it should go
		rigidbody.velocity = transform.forward * speed;
	}
}
