using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 velocity = new Vector3(Random.Range(10, 15), 0, 0);
		rigidbody.velocity = velocity;
	}

	void OnCollisionEnter(Collision other){
		if (Random.value > .6f){
			rigidbody.velocity += new Vector3(0, 0, 2);
		}
		else 
			rigidbody.velocity -= new Vector3(0, 0, 2);
	}
	
}
