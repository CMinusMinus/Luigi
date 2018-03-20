using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 4f;

	public float jumpVelocity = 8;

	new Rigidbody2D rigidbody;

	 public Transform top_left;
 	public Transform bottom_right;
 	public LayerMask ground_layers;
 	bool grounded;

	float jumpCount;
	public float maxJumps = 2;

	[Range(0, 10)]
	public int speed = 5;
 
 void FixedUpdate() {
     grounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);
	 if (grounded) {
		 jumpCount = 0;
	 }    
 }

	void Awake() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (jumpCount < maxJumps && Input.GetButtonDown("Jump")) {
			jumpCount++;
			rigidbody.velocity += Vector2.up * jumpVelocity;
		}

		if (rigidbody.velocity.y < 0) {
			rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rigidbody.velocity.y > 0 && !Input.GetButton("Jump")) {
			rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

		float h = Input.GetAxis("Horizontal");
		
		rigidbody.velocity = new Vector2(h * speed, rigidbody.velocity.y);
		
	}
}
