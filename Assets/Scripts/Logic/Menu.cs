using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//only when space is pressed do we tell director to stop our menu and start our game
		//GetKeyDown means it will only fire off ONCE!
		//otherwise using GetKey would make it continuously do this as long as space is held down!

		if (Input.GetKeyDown(KeyCode.Space)){
			//we defined these functions before, remember?
			Director.main.StopMenu();
			Director.main.StartGame();
		}
	}
}
