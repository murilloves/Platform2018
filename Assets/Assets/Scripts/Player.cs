using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5f;
	public float jumpingForce = 300f;
	public SpriteRenderer spriteRenderer;

	private bool canJump = false;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		// Going right
		if (Input.GetKey("right")) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			spriteRenderer.flipX = false;
		}

		// Going Left
		if (Input.GetKey("left")) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			spriteRenderer.flipX = true;
		}

		// Jumping
		if (Input.GetKeyDown("space") && canJump) {
			GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
			canJump = false;
		}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.transform.name == "Ground") {
			canJump = true;
		}
	}
}
