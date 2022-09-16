using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAnim : MonoBehaviour {
	public Transform endMarker = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
	}
}
