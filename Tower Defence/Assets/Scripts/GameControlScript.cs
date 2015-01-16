using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour {

	//gameobjects
	public GameObject popup;
	public GameObject playButton;
	public GameObject gameOverButton;
	public GameObject buyButtons;
	public GameObject upgradeButtons;
	public GameObject restartButton;

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
	private float chooseText;
	public float damageUpgrade;
	public float rangeUpgrade;
	public float firerateUpgrade;

	void Start ()
	{
		//this text is displayed at the start of the game
		popupText.text = "The year is 20XX…" + "\n" + "\n" + "Humanity made great leaps in all sorts of technological fields. But it wasn’t all hoverboards & laserguns, while the products became more advanced, so did the garbage. And it didn’t take long before this advanced garbage, or smart garbage, stood up against humankind." + "\n" + "\n" + "Luckily, we have the trashmen, our last line of defence. Their cleaning equipment has been modified and you have been put in charge of the entire thrash collecting force. Defend the recycle station as best as you can, it is the only way to process the smart garbage! Upgrade the recycle station to get more recycle power. The more recycle power, the more recycle points you get. If you have no recycle points over, well... Game over...";
	}

	void Update () 
	{

		//each time the factory gameobject loses a life it is mirrored in this script
		totalLives = factoryScript.lives;

		//displays the recycle power, recycle points & current wave on the UI
		scoreText.text = "Recycle Power:" + totalLives + "%" + "\n" + "Recycle Points:" + points + "\n" + "Wave:" + currentWave;

		//resets the spawnEnemy float, so it repeats after spawning 3 enemies
		if(spawnEnemy > 2)
		{
			spawnEnemy = 0;
		}

		//if all enemies have been spawned and destroyed, the popup comes up, the wave goe up, the next enemy type will get spawned, and a random text is chosen to display
		if(totalMaxSpawns == 0 && GameObject.FindWithTag("Enemy") == null)
		{
			popup.SetActive(true);
			currentWave += 1;
			totalMaxSpawns = currentWave*5;
			spawningAllowed = false;
			spawnEnemy ++;
			chooseText = Random.Range(1,4);
			if(chooseText == 1)
			{
				popupText.text = "Congratulations, you have made it to wave " + currentWave + "." + "\n" + "\n" + "Did you know that it takes over 20 years for chewing gum to dissolve? And metal takes 50 years to dissolve! Plastic doesn’t even dissolve at all! That means plastic thrash will roam the earth for as long as it isn’t picked up. Don’t throw your thrash on the ground, throw it in the garbage container!";
			}
			else if(chooseText == 2)
			{
				popupText.text = "Congratulations, you have made it to wave " + currentWave + "." + "\n" + "\n" + "Did you know that electrical appliances still use power when on standby mode? As long as a device is plugged in it uses power. Don’t keep your phone, tablet or music player on the charger when its full, plug it out! And don’t forget to also pull the charger out, because even when there is no phone, the charger still uses power. Not only will the environment thank you, but your electrical bill will be lower as well!";
			}
			else if(chooseText == 3)
			{
				popupText.text = "Congratulations, you have made it to wave " + currentWave + "." + "\n" + "\n" + "Did you know that metal, glass, paper & plastic can be used to make new products? Metal is reused in other metal products, plastic is used to make wrappings or plastic casings, and paper is used to make new paper. Old electronics even contain gold! The plastic and metal in your computer could be made from recycled materials! Don’t just throw things away, sort and recycle them!";
			}
		}

		//if the player has no recycle power left, the gameover popup comes up and the player can restart the game
		if(totalLives == 0)
		{
			popup.SetActive(true);
			playButton.SetActive(false);
			gameOverButton.SetActive(true);
			popupText.text = "Your recycle station has been drained from all its power. You reached wave " + currentWave + ".";
		}
	}
}
