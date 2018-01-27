using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour {
    public int uses;

    public bool Use() {
        if (uses >= 1) {
            uses--;
            return true;
        } else {
            return false;
        }
    }
}
