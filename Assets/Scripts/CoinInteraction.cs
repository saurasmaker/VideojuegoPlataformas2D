using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    //Attributes
    public GameObject getCoinSound;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (getCoinSound != null)  Instantiate(getCoinSound); 
        if (collision.CompareTag("Player")) Destroy(gameObject);
        collision.GetComponentInParent<PlayerController>().coins++;

    }

}
