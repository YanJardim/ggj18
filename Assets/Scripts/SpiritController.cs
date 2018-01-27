using UnityEngine;

public class SpiritController : CharacterControllerBase {

    public new void Start() {
        base.Start();

        GameManager.Instance.spirit = this.gameObject;
    }

    public new void FixedUpdate() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,
                                    Input.GetAxis("Vertical") * speed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Character") {
            gameObject.SetActive(false);
        }
    }
}