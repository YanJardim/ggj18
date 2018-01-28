using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : Activatable {	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Activate() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive(true);
		}
	}

	public override void Deactivate() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive(false);
		}
	}

	
}
