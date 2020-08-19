﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb2d;
    private EdgeCollider2D ec2d;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        ec2d = GetComponent<EdgeCollider2D>();       
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        ec2d.isTrigger = true;

        return;
    }

    void Respawn()
    {
        rb2d.velocity = Vector3.zero;
        transform.position = origin;
        rb2d.isKinematic = true;
        ec2d.isTrigger = false;

        return;
    }
}
