using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;
    
    private AudioSource fallingSound;
    private AudioSource spawnSound;
    private Rigidbody2D rb2d;
    private EdgeCollider2D ec2d;
    private BoxCollider2D bc2d;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        fallingSound = transform.GetChild(0).GetComponent<AudioSource>();
        spawnSound = transform.GetChild(1).GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        ec2d = GetComponent<EdgeCollider2D>();
        bc2d = GetComponent<BoxCollider2D>();

        origin = transform.position;
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
        fallingSound.Play();
        rb2d.isKinematic = false;
        ec2d.isTrigger = true;
        bc2d.isTrigger = true;
    }

    void Respawn()
    {
        spawnSound.Play();
        rb2d.velocity = Vector3.zero;
        transform.position = origin;
        rb2d.isKinematic = true;
        ec2d.isTrigger = false;
        bc2d.isTrigger = false;
    }
}
