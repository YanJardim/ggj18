using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperController : Timer {

	private Rigidbody2D rb;
	private Bounds bounds;
	private GameObject player;
	private AudioSource stomp;

	public bool isElevator = false;

	public float forceUp;
	public float forceDown;
	public float offset;

	public override void Activate() {
		if(isElevator)
			startTimer();
	}

	public override void Deactivate() {

	}

	public override void firstAction() {
		if (isElevator)
			rb.velocity = forceUp * Vector2.up;
		rb.AddForce(Vector2.down * forceDown);

		if(!isElevator) stomp.Play();
	}

	public override void lastAction() {
		
		rb.AddForce(Vector2.up * forceUp);
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		bounds = GetComponent<BoxCollider2D>().bounds;
		stomp = GetComponent<AudioSource>();

		if (!isElevator)
			startTimer();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D other) {

		if(other.gameObject.tag == "Character" && !isElevator) {
			Destroy(other.gameObject);

		}
	}
}
