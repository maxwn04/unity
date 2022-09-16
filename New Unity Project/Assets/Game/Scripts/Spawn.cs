using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public bool canSpawn = false;
	public bool spawn = false;
	public bool spawnTriple = false;
	public bool spawnSpeed = false;
	public bool spawnShield = false;

	public GameObject enemyPrefab;
	public GameObject triplePowerPrefab;
	public GameObject speedPowerPrefab;
	public GameObject shieldPowerPrefab;
	public float randomXPos;
	public float randomYPos;

	// Use this for initialization
	public void StartSpawning(){
		StartCoroutine(waitTriple());
		StartCoroutine(waitEnemy());
		StartCoroutine(waitSpeed());
		StartCoroutine (waitShield ());
		canSpawn = true;
		Instantiate (enemyPrefab,new Vector3 (0,7f, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (spawn&&canSpawn) {
			randomXPos = Random.Range (-9f, 9f);
			randomYPos = Random.Range (7f, 12f);
			Instantiate (enemyPrefab, new Vector3 (randomXPos, randomYPos, 0), Quaternion.identity);
			spawn = false;
			StartCoroutine(waitEnemy());
		}
		if (spawnTriple&&canSpawn) {
			randomXPos = Random.Range (-9f, 9f);
			Instantiate(triplePowerPrefab, new Vector3(randomXPos,7f,0), Quaternion.identity);
			spawnTriple = false;
			StartCoroutine(waitTriple());
		}
		if (spawnSpeed&&canSpawn) {
			randomXPos = Random.Range (-9f, 9f);
			Instantiate(speedPowerPrefab, new Vector3(randomXPos,7f,0), Quaternion.identity);
			spawnSpeed = false;
			StartCoroutine(waitSpeed());
		}

		if (spawnShield&&canSpawn) {
			randomXPos = Random.Range (-9f, 9f);
			Instantiate(shieldPowerPrefab, new Vector3(randomXPos,7f,0), Quaternion.identity);
			spawnShield = false;
			StartCoroutine(waitShield());
		}

	}


	public IEnumerator waitEnemy(){
		int randomTimeE = Random.Range(10,20);
		yield return new WaitForSeconds(randomTimeE);
		spawn = true;
	}

	public IEnumerator waitTriple(){
		int randomTimeT = Random.Range(10,20);
		yield return new WaitForSeconds(randomTimeT);
		spawnTriple = true;
	}

	public IEnumerator waitSpeed(){
		int randomTimeS = Random.Range(10,20);
		yield return new WaitForSeconds(randomTimeS);
		spawnSpeed = true;
	}

	public IEnumerator waitShield(){
		int randomTimeS = Random.Range(10,20);
		yield return new WaitForSeconds(randomTimeS);
		spawnShield = true;
	}

}
