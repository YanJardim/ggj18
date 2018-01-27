using UnityEngine;

public class CharacterControllerBase : MonoBehaviour {
    public float speed;
    private float oldSpeed;
    protected Rigidbody2D rb;

    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    protected void SpeedChange(float newSpeed) {
        oldSpeed = speed;
        speed = newSpeed;
    }
    protected void SpeedRevert() {
        speed = oldSpeed;
    }
}