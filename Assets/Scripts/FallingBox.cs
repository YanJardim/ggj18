using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : Activatable {
    protected Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}

    public override void Activate() {
        rb.gravityScale = 1;
    }
    public override void Deactivate() {
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Character") {
            if (rb.velocity.y <= -5) {
                Debug.Log("Destroy");
                Destroy(other.gameObject);
            } else {
                Debug.Log("Weak FallingBox Hit");
            }
        }
    }
}
