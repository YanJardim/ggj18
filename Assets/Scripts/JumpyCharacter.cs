using UnityEngine;


public class JumpyCharacter : CharacterControllerBase {
    public float jumpHeight;
    public LayerMask groundMask;
    public Transform groundCheck;
    public bool canJump;

    private new void Start() {
        base.Start();
        canJump = true;
    }

    public new void FixedUpdate() {
        base.FixedUpdate();

        if (isGrounded()) {
            if (Input.GetAxis("Fire1") != 0 && canJump) {
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                canJump = false;
            }
        }
    }

    public bool isGrounded() {
        bool result = Physics2D.Linecast(transform.position, groundCheck.position, groundMask);

        if (!result) {
            canJump = true;
            //Debug.DrawLine(transform.position, groundCheck.position, Color.red);
        } else {
            //Debug.DrawLine(transform.position, groundCheck.position, Color.green);
        }

        return result;
    }
}