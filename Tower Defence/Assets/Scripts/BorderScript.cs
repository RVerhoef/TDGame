using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour {

	//
	void OnTriggerExit(Collider obj)
	{
		Destroy(obj.gameObject);
	}
}
