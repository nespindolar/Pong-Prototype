using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Players : MonoBehaviour
{
    public bool player1;
    public float vel; //velocity factor
    public float acc; //acceleration factor
    public float timer, timerNew;
    public Rigidbody2D rb;

    private float move;
    private Vector2 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerNew = timer * acc;

        if (player1)
        {
            move = Input.GetAxisRaw("Vertical");
        }

        else
        {
            move = Input.GetAxisRaw("Vertical2");
        }

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, move * (vel + timerNew));
                
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
        timer = 0;
    }

     

}
