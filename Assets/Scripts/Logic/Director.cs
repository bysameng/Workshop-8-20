using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	public static Director main;

	private GameObject menuObject;
	private GameObject levelObject;
	private GameObject deadMessageObject;

	//do initial setup of entire game here
	void Awake(){
		main = this;
	}


	//initialize things
	void Start(){
		//at the beginning of our game, we should load up our menu
		StartMenu();
	}


	public void StartMenu(){
		//load our menu object from prefabs folder
		GameObject menuPrefab = Resources.Load("Prefabs/Menu") as GameObject;

		//instantiate our menu object
		menuObject = (GameObject)Instantiate(menuPrefab, Vector3.zero, Quaternion.identity);
	}

	public void StopMenu(){
		//we don't need the menuObject anymore! Destroy it!
		Destroy(menuObject);
	}


	public void StartGame(){
		//same thing as menu!
		//load our level object from prefabs folder
		GameObject levelPrefab = Resources.Load("Prefabs/Level") as GameObject;

		//instantiate our level object, same way we instantiate menuObject
		levelObject = (GameObject)Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
	}


	public void StopGame(){
		//same thing yet again
		GameObject deadPrefab = Resources.Load("Prefabs/Dead") as GameObject;

		//instantiate our level object, same way we instantiate menuObject
		deadMessageObject = (GameObject)Instantiate(deadPrefab, Vector3.zero, Quaternion.identity);

		//okay, we're dead. let's restart the game in 3 seconds
		Destroy(levelObject, 3f);
		Destroy(deadMessageObject, 3f);
		Invoke("StartMenu", 3f);
	}

}
