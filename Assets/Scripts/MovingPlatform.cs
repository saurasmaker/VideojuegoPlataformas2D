using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    //Hola mamor
    //Attributes
    public Transform from, to;
    private Vector3 origin, destiny;

    public float speed = 1f;

    private bool back = false;

    // Start is called before the first frame update
    void Start()
    {
        to.parent = null;
        origin = from.position;
        destiny = to.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(from != null && to != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(from.position, to.position, fixedSpeed);
           
            if(transform.position == to.position)
            {
                to.position = (to.position == origin) ? destiny : origin;
            }
        }

        return;
    }

    private bool CheckBack()
    {
        if (transform.position == destiny)
            return true;

        else if (transform.position == origin)
            return false;

        return false;
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }
}
