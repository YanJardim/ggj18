using UnityEngine;


public class StrongCharacter : MonoBehaviour{

    
    public float jumpHeight;
    public LayerMask groundMask;
    public Transform groundCheck;
    private Rigidbody2D rb;
    private bool canJump;


    private void Start() {
         rb = GetComponent<Rigidbody2D>();
         canJump = false;
    }

    public void Update() {
        if(isGrounded()){
            if(Input.GetAxis("Fire1") != 0 && canJump){
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                canJump = false;
            }
        }
    }

    public bool isGrounded()
    {
        bool result = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (!result)
            canJump = true;
          
        return result;
    }
}