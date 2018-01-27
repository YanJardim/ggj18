using UnityEngine;


public class StrongCharacter : MonoBehaviour{

    
    public float jumpHeight;
    public LayerMask groundMask;
    public Transform groundCheck;
    private Rigidbody2D rb;


    private void Start() {
         rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << groundMask, 1.0f)){
            Debug.Log("can jump");
            if(Input.GetAxis("Fire1") != 0){
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }
}