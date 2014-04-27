﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject plat;
	public Vector2 spawnValues;

	// Use this for initialization
	void Start () {
		SpawnWaves ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnWaves() {
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (plat, spawnPosition, spawnRotation);
	}
}
