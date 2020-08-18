﻿using System.Collections;
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

    public bool isGrounded, isJumping, isFalling;

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
        
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb2d.AddForce(Vector2.right * speed * x);
        rb2d.AddForce(Vector2.up * speed * y * 5);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        CheckState(rb2d.velocity.x, rb2d.velocity.y);
        SetAnimations();


        Debug.Log("Velocidad Horizontal: " + rb2d.velocity.x + "\n Velocidad Vertical: " + rb2d.velocity.y + "\n Saltando: " + isJumping + "\n Cayendo: " + isFalling);

        return;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

    private void CheckState(float x, float y)
    {
        if (y < 0) isFalling = true;
        else isFalling = false;

        if (x < 0) transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (x > 0) transform.localScale = new Vector3(1f, 1f, 1f); ;

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
}
