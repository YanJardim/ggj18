using UnityEngine;

public class CharacterControllerBase : MonoBehaviour {
    public float speed;
    protected Rigidbody2D rb;

    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
}