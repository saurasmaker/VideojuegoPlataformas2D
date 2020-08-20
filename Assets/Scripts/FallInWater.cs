using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInWater : MonoBehaviour
{
    public GameObject getFallinWaterSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (getFallinWaterSound != null) Instantiate(getFallinWaterSound);
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();
            p.LoseLife();
        }
    }
}
