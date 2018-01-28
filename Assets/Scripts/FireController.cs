using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : Timer {
	public List<GameObject> childrens;

	private void Start() {
		foreach(Transform c in transform) {
			childrens.Add(c.gameObject);
		}
		SetFogosOnline(false);
	}

	public override void Activate() {
		startTimer();
		SetFogosOnline(true);
	}

	public override void Deactivate() {
		stopTimer();
		SetFogosOnline(false);
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

	public void SetFogosOnline(bool foguinho) {
		foreach (GameObject a in childrens) {
			a.SetActive(foguinho);
		}
	}

}
