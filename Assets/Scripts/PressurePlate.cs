using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    public Activatable activatable;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Box") {
            Debug.Log("Plate pressured");
            activatable.Activate();
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Box") {
            Debug.Log("Plate depressured");
            activatable.Deactivate();
        }
    }
}
