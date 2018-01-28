using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
	public Activatable activatable;
	public AudioSource click;

	private bool isOnArea = false;
	private bool toggle = false;
	
	void Update() {
		if(isOnArea) {
			if (Input.GetKeyDown(KeyCode.E)) {

				if (!toggle) {
					activatable.Activate();
					click.Play();
				} else {
					activatable.Deactivate();
					click.Play();
					Debug.Log("Deactivate lever");
				}

				toggle = !toggle;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Character")
            return;

        if (!other.GetComponent<CharacterControllerBase>().possessed) {
            Debug.Log("not possessed");
            return;
        }
        isOnArea = true;
		Debug.Log("On lever");
	}
	public void OnTriggerExit2D(Collider2D other) {
		isOnArea = false;
		Debug.Log("Leave lever");
	}
}
