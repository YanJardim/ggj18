using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : Timer {
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
