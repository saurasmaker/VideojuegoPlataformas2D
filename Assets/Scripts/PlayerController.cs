using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //Attributes
    public float maxSpeed = 15f;
    public float speed = 10f;

    private Rigidbody2D rb2d;
    private Animator animator;
    private Collider2D collider;

    public bool grounded;
    public int jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Jumping", jumping);

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y > 0) jumping = 1;
        else if (y < 0) jumping = -1;

        rb2d.AddForce(Vector2.right * speed * x);
        rb2d.AddForce(Vector2.up * speed * y);

        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
