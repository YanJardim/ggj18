using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    // Use this for initialization
    public bool activated;
	void Start () {
        activated = false;
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Box") {
            Debug.Log("enter");
            activated = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Box") {
            Debug.Log("exit");
            activated = false;
        }
    }
}
