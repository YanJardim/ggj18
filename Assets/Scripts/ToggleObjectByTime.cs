using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectByTime : Activatable {
	//GameObject obj;
	public float toggleTimer;
	private BoxCollider2D box;
	private bool runCR = false;

	void Start() {
		box = gameObject.GetComponent<BoxCollider2D>();
    }

	IEnumerator ToggleCoroutine() {
		while (runCR) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
            Debug.Log("Deactivated");
			yield return new WaitForSeconds(toggleTimer);
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
            Debug.Log("Activated");
			yield return new WaitForSeconds(toggleTimer);
		}
	}

	public override void Activate() {
		runCR = true;
		StartCoroutine(ToggleCoroutine());
	}

	public override void Deactivate() {
		runCR = false;
		box.enabled = false;
	}
}	
