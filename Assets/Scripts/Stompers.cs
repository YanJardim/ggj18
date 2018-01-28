using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompers : Timer {

	private Rigidbody2D rb;
	private GameObject player;
	private Bounds bounds;

	public float forceDown;
	public float forceUp;
	public float offset;

	public bool isGrounded = false;
	public delegate void StomperDelegate();
	public event StomperDelegate OnTouchGround;
	public override void Activate() {
		new NotImplementedException();
	}

	public override void Deactivate() {
		throw new NotImplementedException();
	}

	public override void firstAction() {
		rb.AddForce(Vector2.down * forceDown);
	}

	public override void lastAction() {
		rb.AddForce(Vector2.up * forceUp);
	}

	// Use this for initialization
	void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
		startTimer();
	}

	// Update is called once per frame
	void Update() {

		player = playerHit();
		print(player);

		if (player) {
			Destroy(player);
		}
		if (isGrounded) {
			isGrounded = false;
			if (OnTouchGround != null)
				OnTouchGround();
		}
	}

	private GameObject playerHit() {
		bounds = gameObject.GetComponent<BoxCollider2D>().bounds;
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(bounds.min.x, bounds.min.y - offset), new Vector2(bounds.max.x, bounds.min.y - offset));
		Debug.DrawLine(new Vector2(bounds.min.x, bounds.min.y - offset), new Vector2(bounds.max.x, bounds.min.y - offset), Color.yellow);
		if (hit.collider != null) {
			if (hit.transform.tag == "Character" && hit.transform.tag != "Spirit")
				return hit.transform.gameObject;
			else if(hit.transform.tag == "Ground") {
				isGrounded = true;
				return null;
			}

		}
		return null;
	}
}
