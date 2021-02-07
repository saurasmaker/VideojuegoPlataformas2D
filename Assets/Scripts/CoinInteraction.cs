using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    //Attributes
    private AudioSource getCoinSound;

    private void Awake()
    {
        getCoinSound = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        getCoinSound.Play();
        PlayerController player = collision.GetComponentInParent<PlayerController>();
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
        player.coins++;

        if (player.coins >= player.coinsToGet)
        {
            player.youWin.enabled = true;
            Time.timeScale = 0;
        }

    }

}
