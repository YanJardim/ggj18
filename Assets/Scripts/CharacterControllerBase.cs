using UnityEngine;

public class CharacterControllerBase : MonoBehaviour {
    public float speed;
    protected Rigidbody2D rb;

    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

    }
}