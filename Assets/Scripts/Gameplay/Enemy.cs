using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float movementX;

	private Vector3 positionBegin;
	private Vector3 positionEnd;

	public float smoothTime = .1f;
	private Vector3 targetPosition;
	private Vector3 velocity;

	private float errorMargin = .1f;

	// Use this for initialization
	void Start () {
		//lets just set the beginning position to where we are right now
		positionBegin = transform.position;
		positionEnd = positionBegin;
		positionEnd.x += movementX;
		//lets set the targetPosition to where we gotta go
		targetPosition = positionEnd;
	}
	
	// Update is called once per frame
	void Update () {

		//if enemy is near our end position, let's set the target back to beginning
		if (Vector3.Distance(transform.position, positionEnd) < errorMargin){
			targetPosition = positionBegin;
		}
		//and vice versa!
		if (Vector3.Distance(transform.position, positionBegin) < errorMargin){
			targetPosition = positionEnd;
		}

		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}

	void OnCollisionEnter(Collision other){
		if  (other.gameObject.tag == "Bullet"){
			Destroy(this.gameObject);
		}
	}
}
