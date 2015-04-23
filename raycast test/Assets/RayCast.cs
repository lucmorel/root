using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

	float distance = 25.0f;
	public float power = 500.0f;
	private float timer = 0.0f;
	private GameObject myObject;
	public GameObject shot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
		if(Input.GetMouseButtonDown(0)){

			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if(Physics.Raycast(rayOrigin, out hitInfo , distance)){

				Debug.Log("Ray Casted");
				Debug.DrawLine(rayOrigin.direction,hitInfo.point);

				if(hitInfo.rigidbody != null){

					myObject = hitInfo.transform.gameObject;
					hitInfo.rigidbody.AddForceAtPosition(rayOrigin.direction * power, hitInfo.point);

					hitInfo.rigidbody.gameObject.renderer.material.color = Color.blue;
					timer = Time.time;

					Instantiate(shot,hitInfo.point,hitInfo.transform.localRotation);

				}
			}
		}

		if(Time.time - timer > 0.2f){
			
			print("CHANGE!!!");
			myObject.renderer.material.color = Color.yellow;
			
		}
		print("time: " + Time.time + " timer: " + timer);
	}
}
