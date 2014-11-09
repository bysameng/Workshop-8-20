using UnityEngine;
using System.Collections;

public class Haha : MonoBehaviour {

	public GameObject message;

	void OnTriggerEnter(Collider other){
		Instantiate(message, Vector3.zero, Quaternion.identity);
	}

}
