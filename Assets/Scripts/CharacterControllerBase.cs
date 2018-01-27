using UnityEngine;

public class CharacterControllerBase : MonoBehaviour {
    public float speed;
    public float facingDirection;
    public float oldDirection;
    protected Rigidbody2D rb;
    protected bool possessed;
    private float oldSpeed;

    protected Altar altar;

    protected void Start() {
        possessed = false;
        altar = null;
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;
        oldDirection = 1;
    }

    public void Update() {
        if (!possessed) {
            return;
        }

        if (altar && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Alter Try Use");
            if (altar.Use()) {
                Depossess();
            }
        }
        UpdateFacingDirection();
    }

    public void FixedUpdate() {
        if (!possessed) {
            return;
        }
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
    }

    public void Depossess() {
        possessed = false;
        GameManager.Instance.SpawnSpirit(transform.position);
    }

    public void OnDestroy() {
        if (possessed) {
            Depossess();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Altar") {
            altar = other.gameObject.GetComponent<Altar>();
            Debug.Log("entered altar");
        }
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Altar") {
            altar = null;
            Debug.Log("exited altar");
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Spirit") {
            if(other.gameObject.GetComponent<SpiritController>().possessionCooldown >= 0)
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

    private void UpdateFacingDirection() {
        facingDirection = Input.GetAxisRaw("Horizontal") != 0 ? Input.GetAxisRaw("Horizontal") : facingDirection;
        if(oldDirection != facingDirection) {
            // changed direction
            Debug.Log("changed direction");
            transform.Rotate(0, 180, 0, Space.World);
        }

        oldDirection = facingDirection;
    }
}