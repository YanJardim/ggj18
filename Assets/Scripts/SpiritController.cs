using UnityEngine;

public class SpiritController : CharacterControllerBase {
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
        if(Cooldown(ref possessionCD)) {
            col.enabled = true;
        }
        if(possessionCD > 0) {
            rb.AddForce(Vector2.up *1200 * (possessionCD / possessionCooldown));
        }

    }

    public void OnEnable() {
        if (rb != null)
            rb.AddForce(Vector2.up * 20);
            //rb.velocity = new Vector2(0f, 1000f);

        possessionCD = possessionCooldown;
        if(col != null)
            col.enabled = false;
    }

    public new void FixedUpdate() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,
                                    Input.GetAxis("Vertical") * speed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(possessionCD > 0) {
            return;
        }
        if (other.gameObject.tag == "Character") {
            gameObject.SetActive(false);
        }
    }
}