using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour {

	//gameobjects
	public GameObject popup;

	//scripts
	public FactoryScript factoryScript;

	//texts
	public Text scoreText;
	public Text popupText;

	//bools
	public bool spawningAllowed;
	public bool pointSelected;

	//floats
	public float points;
	public float totalLives;
	public float totalMaxSpawns;
	public float currentWave;
	public float spawnEnemy;
	public float chooseText;

	void Start ()
	{
		popupText.text = "The year is 20XX…" + "\n" + "\n" + "humanity made great leaps in all sorts of technological fields. But it wasn’t all hoverboards & laserguns, while the products became more advanced, so did the garbage. And it didn’t take long before this advanced garbage, or smart garbage, stood up against humankind." + "\n" + "\n" + "Luckily, we have the trashmen, our last line of defence. Their cleaning equipment has been modified and you have been put in charge of the entire thrash collecting force. Defend the recycle station, it is the only way to process the smart garbage!";
	}

	void Update () 
	{

		//each time the factory gameobject loses a life it is mirrored in this script
		totalLives = factoryScript.lives;

		//
		scoreText.text = "Lives:" + totalLives +" Points:" + points +" Wave:" + currentWave;

		if(spawnEnemy > 2)
		{
			spawnEnemy = 0;
		}

		//
		if(totalMaxSpawns == 0 && GameObject.FindWithTag("Enemy") == null)
		{
			popup.SetActive(true);
			currentWave += 1;
			totalMaxSpawns = currentWave*5;
			spawningAllowed = false;
			spawnEnemy ++;
			chooseText = Random.Range(1,6);
			if(chooseText == 1)
			{
				popupText.text = "I work";
			}
			else if(chooseText == 2)
			{
				popupText.text = "I work";
			}
			else if(chooseText == 3)
			{
				popupText.text = "I work";
			}
			else if(chooseText == 4)
			{
				popupText.text = "I work";
			}
			else if(chooseText == 5)
			{
				popupText.text = "I work";
			}
		}
	
	}
}
