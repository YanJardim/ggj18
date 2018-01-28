using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerController : CharacterControllerBase {
    public float speedOnWater;
    bool onWater;
    public float gravityScaleOnWater;
	public AudioSource bubbles;

    public new void Update() {
        if (onWater) {
            if (!possessed) {
                return;
            }
            rb.velocity += new Vector2(Input.GetAxis("Horizontal") * speedOnWater,
                        Input.GetAxis("Vertical") * speedOnWater);

			if (anim == null) return;

			if (Input.GetAxisRaw("Vertical") != 0) {

				if(bubbles != null)
					bubbles.Play();

				anim.SetBool("Walk", true);
			} else {
				timer += Time.deltaTime;
				if (timer >= 0.2f) {
					anim.SetBool("Walk", false);
					timer = 0;
				}
			}

		} else {
            base.Update();
        }
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Water") {
			if (rb == null) rb = GetComponent<Rigidbody2D>();

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
