using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInWater : MonoBehaviour
{
    private AudioSource fallingWaterSound;
    private PlayerController pc;

    private void Awake()
    {
        fallingWaterSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Player"))
        {
            pc = collision.GetComponent<PlayerController>();
            if (pc.canDie)
            {
                pc.canDie = false;
                fallingWaterSound.Play();
                PlayerController p = collision.gameObject.GetComponent<PlayerController>();
                p.LoseLife();
                Invoke(nameof(SetCanDieTrue), 0.5f);
            }
        }
    }

    public void SetCanDieTrue()
    {
        pc.canDie = true;
    }
}
