using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour {

    public Rigidbody2D rb;

    public PressurePlate plate;
    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Active();
	}

    public void Active() {
        if(plate.activated)
            rb.gravityScale = 1;
    }
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Destroy");
            Destroy(other.gameObject);
        }
    }
}
