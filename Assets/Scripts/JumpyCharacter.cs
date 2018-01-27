using UnityEngine;


public class JumpyCharacter : Character{
    public float jumpHeight;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool canJump;

    private new void Start() {
        base.Start();
         canJump = true;
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
        bool result = Physics2D.Linecast(transform.position, groundCheck.position, 1 << groundMask);

        if (!result)
            canJump = true;
          
        return result;
    }
}