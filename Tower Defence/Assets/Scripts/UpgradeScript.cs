using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour {
	
	//scripts
	public GameControlScript gameControlScript;
	public FactoryScript factoryScript;
	
	//audio
	public AudioClip canBuy;
	public AudioClip cantBuy;
	
	//gameobject
	public GameObject upgradeButton;
	public GameObject factory;

	//floats
	public float cost;
	public float damage;
	public float firerate;
	public float range;
	public float repair;

	//the upgrade function is called when a button is pressed, the function raises one value, as only one value has been assigned to be greater than 1 in the inspector. the value is used to either raise one ascpect of the turrets or raise the players recycle power
	public void Upgrade () 
	{
		gameControlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
		factoryScript = GameObject.Find("Factory").GetComponent<FactoryScript>();

		if(gameControlScript.points >= cost)
		{
			audio.PlayOneShot(canBuy);
			gameControlScript.points -= cost;	
			gameControlScript.damageUpgrade += damage;
			gameControlScript.firerateUpgrade += firerate;
			gameControlScript.rangeUpgrade += range;
			factoryScript.lives += repair;
			upgradeButton.SetActive(false);
			factory.GetComponent<SpriteRenderer>().color = Color.white;
		}
		//if the player doesn't have enough point a sound is played
		else
		{
			audio.PlayOneShot(cantBuy);
		}
		
	}
}
