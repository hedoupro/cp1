using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerController2D : MonoBehaviour
{
    public float speed;
    public float smooth;
    Rigidbody2D rb2d;
    Animator animator;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
       
        float x = Input.GetAxisRaw("Horizontal") * speed;
       
     
        rb2d.velocity = new Vector2(x,rb2d.velocity.y);
        animator.SetBool("Running", x!=0); 

     animator.SetBool("Jumping", !grounded);
    
        if (x > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        else if (x< 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }
bool grounded;
public Collider2D groundCheck;
public LayerMask groundLayer;
private void Update()
    {
        
        // Is the player touching the ground ?
        grounded = groundCheck.IsTouchingLayers(groundLayer);
        Debug.Log(grounded);
				
		// Only jump if the player is grounded and has pressed the Space bar
				
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            rb2d.AddForce(new Vector2(0f, jumpForce));
				
    }
 bool facingRight = true;
void Flip()
    {
        
        facingRight = !facingRight;

        
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
        animator.SetBool("Jumping", !grounded); 
    }
}
