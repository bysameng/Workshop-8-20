using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy"){
			Director.main.StopGame();
			Destroy(this.gameObject);
		}
	}
}
