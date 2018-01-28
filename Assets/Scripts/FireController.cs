using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : Timer {
	private BoxCollider2D box;

	// Use this for initialization
	void Start () {
		box = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Activate() {
		startTimer();
	}

	public override void Deactivate() {
		stopTimer();
	}

	public override void firstAction() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive(false);
		}
		Debug.Log("Deactivated");
	}

	public override void lastAction() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive(true);
		}
		Debug.Log("Activated");
	}


}
