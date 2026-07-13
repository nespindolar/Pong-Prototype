using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AI : MonoBehaviour
{
    public static float vel;
    public float velTest;
    public float acc;

    public float timer, timerNew;

    public GameObject ball;    
    private Vector2 ballPos;

    private Vector2 startPos;

    private float minValue = -3.0f;
    private float maxValue = 3.0f;
    public float timeInterval = 0.5f;
    private float randomPos;
    private float timeElapsed = 0.0f;




    void Start()
    {
        startPos = transform.position;        
        timer = 0;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        timerNew = timer * acc;

        Vector2 iaPos = ball.GetComponent<Scr_Ball>().hitPos;
        float ballVelX = ball.GetComponent<Scr_Ball>().velX;
        
        ballPos = ball.transform.position;

        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeInterval)
        {
            timeElapsed = 0.0f;
            GenRandomPos();
        }        

        if (ballVelX <= 0)
        {
            if (transform.position.y > randomPos)
            {
                transform.position += new Vector3(0, -(velTest * Time.deltaTime + timerNew), 0);
            }

            if (transform.position.y < randomPos)
            {
                transform.position += new Vector3(0, (velTest * Time.deltaTime + timerNew), 0);
            }
        }

        else if (ballVelX > 0 && ballPos.x < 1)
        {
            if (transform.position.y > ballPos.y)
            {
                transform.position += new Vector3(0, -(velTest * Time.deltaTime + timerNew), 0);
            }

            if (transform.position.y < ballPos.y)
            {
                transform.position += new Vector3(0, (velTest * Time.deltaTime + timerNew), 0);
            }
        }

        else
        {
            if (transform.position.y > iaPos.y)
            {
                transform.position += new Vector3(0, -(velTest * Time.deltaTime + timerNew), 0);
            }

            if (transform.position.y < iaPos.y)
            {
                transform.position += new Vector3(0, (velTest * Time.deltaTime + timerNew), 0);
            }
        }      
                
    }

    public void Reset()
    {
        transform.position = startPos;
        timer = 0;        
    }
        void GenRandomPos()
    {
        randomPos = Random.Range(minValue, maxValue);        
    }
}

