using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float playerSpeed = 5.0f;

	// Use this for initialization
	void Start () {

		//spawn player

		//this is where our player will start

		transform.position = new Vector3(-2, -3, 0);
	
	}
	
	// Update is called once per frame
	void Update () {

		//player to move whan key pressed
		transform.Translate (Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
		transform.Translate (Vector3.up * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
	
	}

	void onGUI(){

		//make a background
		GUI.Box(new Rect(10,10,100,200),"Content");

	}
}
