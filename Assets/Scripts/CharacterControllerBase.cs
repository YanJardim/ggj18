using UnityEngine;

public class CharacterControllerBase : MonoBehaviour {
    public float speed;
    public float facingDirection;
    public float oldDirection;
    public LayerMask groundMask;
    public float offset;
    protected Rigidbody2D rb;
    protected bool possessed;
    private float oldSpeed;

    private Bounds bounds;

    protected Altar altar;

    protected void Start() {
        possessed = false;
        altar = null;
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;
        oldDirection = 1;

		if(gameObject.tag == "Character") {
			GameManager.Instance.alive++;
		}
    }

    public void Update() {
        if (!possessed) {
            return;
        }

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        UpdateFacingDirection();
    }
    

    public void Depossess() {
        possessed = false;
        GameManager.Instance.SpawnSpirit(transform.position);
    }

    public void OnDestroy() {
		if (gameObject.tag == "Character")
			GameManager.Instance.alive--;

        if (possessed) {
            Depossess();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Spirit") {
            if(other.gameObject.GetComponent<SpiritController>().possessionCooldown >= 0)
                possessed = true;
        }
    }

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "FatalObject") {
			Destroy(gameObject);
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

    public bool isGrounded()
    {
        bounds = gameObject.GetComponent<BoxCollider2D>().bounds;

        Debug.DrawLine(new Vector2(bounds.min.x, bounds.min.y- offset), new Vector2(bounds.max.x, bounds.min.y - offset), Color.yellow);
        bool result = Physics2D.Linecast(new Vector2(bounds.min.x, bounds.min.y - offset), new Vector2(bounds.max.x, bounds.min.y - offset), groundMask);

        return result;
    }
}