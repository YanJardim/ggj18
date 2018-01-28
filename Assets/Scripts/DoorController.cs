﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Activatable {

	private Rigidbody2D rb;

	public override void Activate() {
		rb.gravityScale = 1;
	}

	public override void Deactivate() {
		rb.gravityScale = 0;
		rb.AddForce(Vector2.up * 100);
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
