using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{ 

    //Psysics Attributes
    public float maxSpeed = 15f;
    public float speed = 10f;
    public float jumpPower = 9.25f;
    public float friction = 0.75f;

    private Rigidbody2D rb2d;
    private Animator animator;

    private bool isGrounded, isJumping, isFalling;

    //Sonido
    public GameObject jumpingSound;

    //UI
    public Text coinsText;
    public Text lifesText;

    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

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

        coinsText.text = coins.ToString();
        lifesText.text = lifes.ToString();


        SetFriction();

        SetMove();

        Debug.Log("Velocidad Horizontal: " + rb2d.velocity.x + "\n Velocidad Vertical: " + rb2d.velocity.y + "\n Saltando: " + isJumping + "\n Cayendo: " + isFalling);

        return;
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            rb2d.velocity = Vector3.zero;
            transform.parent = collision.transform;
            isGrounded = true;
        }

        return;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {      
            isGrounded = true;  
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = collision.transform;
            isGrounded = true;
        }

        return;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
            isGrounded = false;
        }

        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))       
            LoseLife();
        
        return;
    }


    //My methods
    private void CheckState(float x, float y)
    {
        if (y < 0) { 
            isFalling = true;
            isGrounded = false;
        }
        else isFalling = false;

        if (isJumping && isGrounded) {
            if (jumpingSound != null) Instantiate(jumpingSound);
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
        if (isGrounded) {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity *= friction;
            rb2d.velocity = fixedVelocity;
        }

        

        return;
    }


    public void LoseLife()
    {
        if (lifes > 0)
            Invoke("MoveToSpawn", 0.5f);

        //else GameOver.

        return;
    }

    public void MoveToSpawn()
    {
        transform.position = new Vector3(-12, -3, -1);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        --lifes;

        return;
    }

    //Gameplay Attributes
    public int coins = 0;
    public int lifes = 3;
}
