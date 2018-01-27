using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour {
    public int uses;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

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
