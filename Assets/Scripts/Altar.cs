using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour {
    public int uses;
	private CharacterControllerBase character;

	private bool isOnArea = false;

	void Update() {
		if (character && isOnArea && Input.GetKeyDown(KeyCode.E) && Use()) {
			character.Depossess();
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Character")
			character = other.GetComponent<CharacterControllerBase>();

		isOnArea = true;
		Debug.Log("On Altar");
	}
	public void OnTriggerExit2D(Collider2D other) { 
		if (other.gameObject.tag == "Character")
			character = null;
		isOnArea = false;
		Debug.Log("Leave altar");
	}

	public bool Use() {
        if (uses >= 1) {
            uses--;
            return true;
        } else {
            return false;
        }
    }
}
