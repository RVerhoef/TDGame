using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour {

	//destroys all object hitting the border, used to get rid of stray bullets
	void OnTriggerExit(Collider obj)
	{
		Destroy(obj.gameObject);
	}
}
