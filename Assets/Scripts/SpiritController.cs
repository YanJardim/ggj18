using UnityEngine;

public class SpiritController : CharacterControllerBase {
	public float depossessSpeed;

	public float possessionCooldown;
	[HideInInspector]
	public float possessionCD;

	protected Collider2D col;

	public void Awake() {
		col = GetComponent<Collider2D>();
	}

	public new void Start() {
		base.Start();

		GameManager.Instance.spirit = this.gameObject;
	}
	public bool Cooldown(ref float CD) {
		if (CD > 0) {
			CD -= Time.deltaTime;

			if (CD <= 0f) {
				CD = 0f;
				return true;
			}
		}
		return false;
	}

	public new void Update() {
        if (Cooldown(ref possessionCD)) {
            col.enabled = true;
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,
                                    Input.GetAxis("Vertical") * speed);
        if (possessionCD > 0) {
            rb.AddForce(Vector2.up * depossessSpeed * (possessionCD / possessionCooldown));
        }

    }

	public void OnEnable() {
		possessionCD = possessionCooldown;

		if (col != null)
			col.enabled = false;
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (possessionCD > 0) {
            return;
        }
        if (other.gameObject.tag == "Character") {
            gameObject.SetActive(false);
        }
    }
}