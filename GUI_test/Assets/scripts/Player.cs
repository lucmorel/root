using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTransform;
	public int playerSpeed = 15;
	public GameObject ProjectileFab;
	public GameObject EnnemyFab;
	public static int lives = 3;
	public static int score = 0;
	public float timer = 0.0f;




	private int ennemyTimer =0;
	private int ennemyTrigger = 12;

	// Use this for initialization
	void Start () {

		myTransform = transform;
		myTransform.position = (new Vector3 (0, -3, 0));
	
	}
	
	// Update is called once per frame
	void Update () {

		//move left or right
		myTransform.Translate (Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);

		//wrap around
		//if player is at extremeleft apear extrem right
		if (myTransform.position.x < -11) {
			myTransform.position = (new Vector3(11,myTransform.position.y,myTransform.position.z));
		}
		else if(myTransform.position.x > 11) {
			myTransform.position = (new Vector3(-11,myTransform.position.y,myTransform.position.z));
		}

		//shoot
		if(Input.GetKeyDown("space")){

			//set position
			ProjectileFab.transform.position = myTransform.position;
			ProjectileFab.transform.position = new Vector3(myTransform.position.x,myTransform.position.y +1,myTransform.position.z);

			//fire
			Instantiate(ProjectileFab);
		}

		//ennemy spawner trigger
		ennemyTimer = ennemyTimer >= 0 ? ennemyTimer = Random.Range(0,100):-1;
		if(ennemyTimer == ennemyTrigger){

			//set position
			EnnemyFab.transform.position = new Vector3(Random.Range(-10,10),7.5f,0);

			//spawn
			Instantiate(EnnemyFab);

			//break monster spawner
			//ennemyTimer = -1;
		}

		if(lives == 0){

			Destroy(this.gameObject);

		}

		if(Time.time - timer > 0.25f){

			renderer.enabled = true;
		}

		print("LIVES: " + lives + " SCORE: " + score + "      TIME: " + Time.time + "    TIMER: " + timer);

	}

	void OnTriggerEnter(Collider collider){

		//destroy on ennemy
		if(collider.gameObject.CompareTag("EnnemyFab")){

			renderer.enabled = false;
			timer = Time.time;
			lives--;

		}
	}
}
