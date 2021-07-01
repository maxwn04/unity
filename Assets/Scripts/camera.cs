using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class camera : MonoBehaviour {

	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 5f;
	// the height we want the camera to be above the target
	public float height = 2f;
	// How much we 
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;

	public GameObject xPlusSide;
	public GameObject xMinusSide;
	public GameObject zPlusSide;
	public GameObject zMinusSide;

	public float boundxP;
	public float boundxM;
	public float boundzP;
	public float boundzM;


	// Place the script in the Camera-Control group in the component menu
	[AddComponentMenu("Camera-Control/Smooth Follow")]

	void LateUpdate(){
		if (transform.position.x < boundxM) {
			xMinusSide.SetActive (false);
		}else{
			xMinusSide.SetActive(true);
		}
		if(transform.position.x > boundxP){
			xPlusSide.SetActive (false);
		}else{
			xPlusSide.SetActive(true);
		}
		if(transform.position.z < boundzM){
			zMinusSide.SetActive (false);
		}else{
			zMinusSide.SetActive(true);
		}
		if(transform.position.z > boundzP){
			zPlusSide.SetActive (false);
		}else{
			zPlusSide.SetActive(true);
		}
			
		follow ();

	}
	void follow () {
		// Early out if we don't have a target
		if (!target) return;

		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);

		// Always look at the target
		transform.LookAt(target);
	}
} 