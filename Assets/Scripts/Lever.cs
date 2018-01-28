using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
	public Activatable activatable;

	private bool isOnArea = false;
	private bool toggle = false;

	void Update() {
		if(isOnArea) {
			if (Input.GetKeyDown(KeyCode.E)) {

				if (!toggle) {
					activatable.Activate();
				} else {
					activatable.Deactivate();
				}

				toggle = !toggle;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other) { 

		isOnArea = true;
		Debug.Log("On lever");
	}
	public void OnTriggerExit2D(Collider2D other) {
		isOnArea = false;
		Debug.Log("Leave lever");
	}
}
