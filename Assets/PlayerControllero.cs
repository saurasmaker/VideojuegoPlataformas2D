using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControllero : MonoBehaviour
{
    public float maxVelocidad = 7f;
    public float velocidad = 3f;

    private Rigidbody2D Cuerpo;

    // Start is called before the first frame update
    void Start()
    {
        Cuerpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        Cuerpo.AddForce(Vector2.right * velocidad * h);

        if (Cuerpo.velocity.x > maxVelocidad)
        {
            Cuerpo.velocity = new Vector2(maxVelocidad, Cuerpo.velocity.y);
        }
        if (Cuerpo.velocity.x < -maxVelocidad)
        {
            Cuerpo.velocity = new Vector2(-maxVelocidad, Cuerpo.velocity.y);
        }
    }
}
