using UnityEngine;
using System.Collections;
public class FactoryScript : MonoBehaviour {

	//gameobjects
	public GameObject upgradeButton;

	//scripts
	public GameControlScript gameControlScript;

	//floats
	public float lives;

	//finds the gamecontrolscript
	void Start()
	{
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}

	//if the player has no recycle power left, this object is destroyed
	void Update()
	{
		if(lives == 0)
		{
			Destroy(this.gameObject);
		}
	}

	//if a gameobject with the tag enemy gets close, it gets destroyed and a life is substracted
	void OnTriggerEnter(Collider obj)
	{
		if (obj.gameObject.tag == "Enemy") 
		{
			lives -= 10;
			Destroy(obj.gameObject);
		}
	}

	//if the player holds the mouse over this object and clicks, he opens the upgrade menu
	void OnMouseOver () 
	{
		if(Input.GetMouseButtonDown(0) && gameControlScript.spawningAllowed == true)
		{
			if(gameControlScript.pointSelected == false)
			{
				upgradeButton.SetActive(true);
				gameControlScript.pointSelected = true;
				GetComponent<SpriteRenderer>().color = Color.gray;
			}
			
			else if(gameControlScript.pointSelected == true)
			{
				upgradeButton.SetActive(false);
				gameControlScript.pointSelected = false;
				GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}
}
