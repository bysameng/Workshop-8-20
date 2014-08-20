using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {


	public GameObject objectToFollow;

	private Vector3 targetPosition;
	private Vector3 velocity;
	private float smoothTime = .2f;

	// Update is called once per frame
	void Update () {
		targetPosition = objectToFollow.transform.position + new Vector3(0, 2, -10f);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
