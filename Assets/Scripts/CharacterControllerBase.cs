using UnityEngine;

public class CharacterControllerBase : MonoBehaviour {
    public float speed;
    private float oldSpeed;
    protected Rigidbody2D rb;
    protected bool possessed;

    protected void Start() {
        possessed = false;
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        if(!possessed) {
            return;
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    public void OnDestroy() {
        if (possessed) {
            GameManager.Instance.SpawnSpirit(transform.position);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Spirit") {
            possessed = true;
        }
    }

    protected void SpeedChange(float newSpeed) {
        oldSpeed = speed;
        speed = newSpeed;
    }
    protected void SpeedRevert() {
        speed = oldSpeed;
    }
}