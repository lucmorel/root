using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour {



	void OnGUI()
	{

		GUI.Box(new Rect(10,10,500,20),"LIVES: " + Player.lives + " SCORE: " + Player.score + "    TIMER: "+ Mathf.Round(Time.time));


	}
}
