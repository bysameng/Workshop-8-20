﻿using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		}
	}
}
