using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {

	//private
	private Transform myTransform;
	private int minEnnemyPos = -13;
	private int maxEnnemyPos = 13;
	private int ennemySpeed;
	private int ennemyPos;

	//public
	public int minSpeed = 5;
	public int maxSpeed = 9;


	// Use this for initialization
	void Start () {

		myTransform = transform;
		ennemySpeed = Random.Range(minSpeed,maxSpeed);
	}


	// Update is called once per frame
	void Update () {

		//deplace l'ennemy par en bas
		myTransform.Translate(Vector3.down * ennemySpeed * Time.deltaTime);

		//si l'ennemy sort du champ de vision en bas le replacer en haut nimporte ou avec une vitesse random
		if(myTransform.position.y < -6){

			myTransform.position = new Vector3(Random.Range(minEnnemyPos,maxEnnemyPos),7.5f,0);
			ennemySpeed = Random.Range(minSpeed,maxSpeed);
		}
	}

	void OnTriggerEnter(Collider collider){
		//destroy on bullet
		if(collider.gameObject.CompareTag("ProjectileFab")){

			Destroy(this.gameObject);
		}

		//destroy on player
		if(collider.gameObject.CompareTag("Player")){
			
			Destroy(this.gameObject);
		}
	}
}
