using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfLimits : MonoBehaviour
{
    public EdgeCollider2D ec2dMirror;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(ec2dMirror.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z); 
        }
    }
}
