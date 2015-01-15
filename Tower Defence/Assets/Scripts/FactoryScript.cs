using UnityEngine;
using System.Collections;
public class FactoryScript : MonoBehaviour {

	//floats
	public float lives;

	void OnTriggerEnter(Collider obj)
	{
		//if a gameobject with the tag enemy gets close, it gets destroyed and a life is substracted
		if (obj.gameObject.tag == "Enemy") 
		{
			lives -= 1;
			Destroy(obj.gameObject);
		}
	}

	void onMouseOver()
	{

	}
}
