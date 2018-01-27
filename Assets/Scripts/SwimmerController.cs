using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerController : CharacterControllerBase {
    public float speedOnWater;
    bool onWater;
    public float gravityScaleOnWater;

    public new void FixedUpdate() {
        if (onWater) {
            if (!possessed) {
                return;
            }
            rb.velocity += new Vector2(Input.GetAxis("Horizontal") * speedOnWater,
                        Input.GetAxis("Vertical") * speedOnWater);
        } else {
            base.FixedUpdate();
        }
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Water") {
            rb.gravityScale = gravityScaleOnWater;
            onWater = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Water") {
            rb.gravityScale = 1f;
            onWater = false;
        }
    }
}
