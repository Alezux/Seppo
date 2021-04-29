using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script gives the movemenet for player
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    public bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Animator anim;
    public int Jumps;
    public int JumpsValue;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //Päivittäessä pelaaja voi liikkua vasenta ja oikeaa näppäintä painamalla
    void FixedUpdate()
    {
        //This will give the gravity to player
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //This will give movement to player by pressing the arrow buttons
        moveInput = (Input.GetAxis("Horizontal"));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //This will give the player running animation when the player is moving
        if (moveInput > 0 || moveInput < 0)
        {
            anim.SetTrigger("run");
        }

        //This will give the player idle animation when the player is not moving
        else
        {
            anim.SetTrigger("idle");
        }

        //This will change the player direction to left when pressing left button
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        //This will change the player direction to right when pressing right button
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        //If player is not in air, player can jump. With this logic the player can only jump once from the ground.
        if(isGrounded == true)
        {
            Jumps = JumpsValue;
        }

        //This will make the player jump when pressing the button and gives the jump animation
        if (Input.GetButtonDown("Jump") && Jumps == 0 && isGrounded == true)
        {
            anim.SetTrigger("jump");
            rb.velocity = Vector2.up * jumpForce;
            Jumps--;
        }

        //When player is in the air, the player will stop doing the jump animation
        if (Input.GetButtonDown("Jump") && Jumps == 0 && isGrounded == false)
        {
            anim.ResetTrigger("jump");
            anim.SetTrigger("idle"); 
        }

    }

    //When calling this function, the player will change the direction towards what arrow button you click
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
