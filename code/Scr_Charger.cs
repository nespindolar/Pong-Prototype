using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Charger : MonoBehaviour
{
    public float charge = 0;   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
            charge += 1;
    }
}
