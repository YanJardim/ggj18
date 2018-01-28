using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateMultiple : MonoBehaviour {
    public List<Activatable> activatable;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Character" || other.tag == "Box") {
            Debug.Log("Plate pressured");

            foreach (Activatable a in activatable)
                a.Activate();
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Character" || other.tag == "Box") {
            Debug.Log("Plate depressured");
            foreach (Activatable a in activatable)
                a.Deactivate();
        }
    }
}
