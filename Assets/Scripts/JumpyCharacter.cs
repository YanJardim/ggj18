using UnityEngine;


public class JumpyCharacter : CharacterControllerBase {
    public float jumpHeight;
    public bool canJump;
	private AudioSource jumpSound;
    private new void Start() {
        base.Start();
        canJump = true;
		jumpSound = GetComponent<AudioSource>();
    }

    public new void Update() {
        base.Update();

        if (!possessed) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("jump pressed");
            if (isGrounded()) {
                Debug.Log(rb.velocity);
				jumpSound.Play();
				rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
			}
        }
    }
}