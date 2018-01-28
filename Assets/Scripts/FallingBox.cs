﻿using System;
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

    public void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;

        if (collision.gameObject.tag == "Character") {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            //bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;

            if (Mathf.Abs(rb.velocity.y) >= 5 && !top) {
                Debug.Log("Destroy");
                Destroy(collision.gameObject);
            } else {
                Debug.Log("Weak FallingBox Hit");
            }
        }
    }
}
