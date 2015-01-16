using UnityEngine;
using System.Collections;

public class GameOverButton : MonoBehaviour {

	//loads level 0, the menu
	public void Gameover () 
	{
		Application.LoadLevel(0);
	}
}
