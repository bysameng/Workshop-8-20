using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {


	private Vector2 velocity;
	private Vector2 movement;
	private float speed = 5f;
	private float acceleration = 40f;
	private float deceleration = 50f;
	private bool onGround;
	private float jumping;


	private float gravity = -20f;

	void Start(){
	}

	void Update () {
		onGround = CheckGround();

		//get side to side movement
		movement.x = Input.GetAxisRaw("Horizontal") * acceleration;
		if (!onGround){
			movement.x /= 2f;
		}

		if (Input.GetButtonDown("Jump") && onGround){
			Jump();
		}

		if (jumping > 0){
			jumping -= Time.deltaTime;
			onGround = false;
			movement.y = 100f;
		}


		if (!onGround && jumping <= 0){
			movement.y = gravity;
		}



		//set movement independent of framerate
		movement *= Time.deltaTime;

		//update velocity
		velocity += movement;
		if (movement.x == 0){
			velocity.x = Decelerate(velocity.x, deceleration * Time.deltaTime);
		}
		velocity.x = Mathf.Clamp(velocity.x, -speed, speed);
		if (onGround){velocity.y = 0;}

		//apply velocity
		rigidbody.velocity = velocity;

	}


	bool CheckGround(){
		Vector3 rayOriginLeft = transform.position;
		Vector3 rayOriginRight = rayOriginLeft;
		rayOriginLeft.x += collider.bounds.size.x/2;
		rayOriginRight.x -= collider.bounds.size.x/2;
		bool left = Physics.Raycast(rayOriginLeft, Vector3.down, collider.bounds.size.y / 2 + .1f);
		bool right = Physics.Raycast(rayOriginRight, Vector3.down, collider.bounds.size.y / 2 + .1f);
		return (left || right);
	}



	void Jump(){
		onGround = false;
		jumping = .1f;
	}

	void OnCollisionEnter(Collision other){
		if (other.contacts[0].normal == Vector3.down){
			velocity.y = 0;
		}
		else if (other.contacts[0].normal != Vector3.up){
			velocity.x = -velocity.x;
		}

	}


	float Decelerate(float value, float deceleration){
		if (value > 0){
			value -= deceleration;
			if (value < 0) value = 0;
		}
		else if (value < 0){
			value += deceleration;
			if (value > 0) value = 0;
		}
		return value;
	}

}
