using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Transform myTransform;
	public int projectileSpeed = 20;

	// Use this for initialization
	void Start () {

		myTransform = transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		//deplace la balle par en haut
		myTransform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);

		//si la balle sort par en haut la detruire
		if (myTransform.position.y > 7){

			DestroyObject(this.gameObject);

		}
	
	}

	void OnTriggerEnter(Collider collider){

		//destroy on enney
		if(collider.gameObject.CompareTag("EnnemyFab")){

			Player.score += 50;
			Destroy(this.gameObject);
		}
	}
}
