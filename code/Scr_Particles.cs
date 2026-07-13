using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Particles : MonoBehaviour
{
    public GameObject ball;

    public float dirVelX;
    public float dirVelY;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = ball.transform.position;
        dirVelX = ball.GetComponent<Scr_Ball>().rb.linearVelocity.x;
        dirVelY = ball.GetComponent<Scr_Ball>().rb.linearVelocity.y;

        if (dirVelX>0 && dirVelY >0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }

        if (dirVelX < 0 && dirVelY > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }

        if (dirVelX < 0 && dirVelY < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }

        if (dirVelX > 0 && dirVelY < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -135);
        }
    }
}
