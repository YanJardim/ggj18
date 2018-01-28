using UnityEngine;


public class JumpyCharacter : CharacterControllerBase {
    public float jumpHeight;
    public bool canJump;

    private new void Start() {
        base.Start();
        canJump = true;
    }

    public new void FixedUpdate() {
        base.FixedUpdate();

        if (!possessed) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded()) {
                Debug.Log(rb.velocity);

                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }
}