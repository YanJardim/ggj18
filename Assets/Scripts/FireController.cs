using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : Timer {
	public List<GameObject> childrens;
	public SpriteRenderer lever;

	private void Start() {
		foreach(Transform c in transform) {
			childrens.Add(c.gameObject);
		}
		SetFogosOnline(false);
	}

	public override void Activate() {
		startTimer();
		SetFogosOnline(true);
		lever.flipX = true;
	}

	public override void Deactivate() {
		stopTimer();
		SetFogosOnline(false);
		lever.flipX = false;
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
