using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

    //Psysics Attributes
    public float maxSpeed = 15f;
    public float speed = 10f;
    public float jumpPower = 9.25f;
    public float friction = 0.75f;

    private Rigidbody2D rb2d;
    private Animator animator;
    private Collider2D coll;

    private bool isGrounded, isJumping, isFalling;



    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.coll = GetComponent<Collider2D>();

        return;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) isJumping = true;
        
        CheckState(rb2d.velocity.x, rb2d.velocity.y);

        SetAnimations();

        return;
    }

    private void FixedUpdate()
    {
        SetFriction();

        SetMove();

        Debug.Log("Velocidad Horizontal: " + rb2d.velocity.x + "\n Velocidad Vertical: " + rb2d.velocity.y + "\n Saltando: " + isJumping + "\n Cayendo: " + isFalling);

        return;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;

        return;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;

        return;
    }

    void OnBecameInvisible()
    {
        LoseLife();

        return;
    }



    //My methods
    private void CheckState(float x, float y)
    {
        if (y < 0) isFalling = true;
        else isFalling = false;

        if (isJumping && isGrounded) { 
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
        }

        if (x < -0.1) transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (x > 0.1) transform.localScale = new Vector3(1f, 1f, 1f); ;

        return;
    }

    private void SetAnimations()
    {
        animator.SetFloat("X Velocity", Mathf.Abs(rb2d.velocity.x));
        animator.SetFloat("Y Velocity", Mathf.Abs(rb2d.velocity.y));
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Jumping", isJumping);
        animator.SetBool("Falling", isFalling);

        return;
    }

    private void SetMove()
    {
        float x = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * x);

        float limitedSpeedX = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeedX, rb2d.velocity.y);

        return;
    }

    private void SetFriction()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity *= friction;

        if (isGrounded) rb2d.velocity = fixedVelocity;

        return;
    }


    private void LoseLife()
    {
        if (lifes > 0)
        {
            transform.position = new Vector3(-12, -3, -1);
            --lifes;
        }

        //else GameOver.

        return;
    }


    //Gameplay Attributes
    public int coins = 0;
    public int lifes = 3;
}
