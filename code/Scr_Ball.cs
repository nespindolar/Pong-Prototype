using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Ball : MonoBehaviour
{
    public float velocidad;
    public float aceleracion;
    public float timer, timerNew;
    public float velX;
    public float velY;

    public float delayLaunch = 1;

    public Rigidbody2D rb;

    private Vector2 startPos;

    public AudioSource bounceSound;    
    
    public GameObject reflectionWall2;
    private string reflectionWall2Tag;
    private int maxReflexions = 10;
    private float maxRayDistance = 20.0f;

    public Vector2 hitPos;

    public float forceMultiplier = 2f;

    void Start()
    {
        startPos = transform.position;

        bounceSound = GetComponent<AudioSource>();

        //Delay launch
        StartCoroutine(CallMethodAfterDelay());
        IEnumerator CallMethodAfterDelay()
        {            
            yield return new WaitForSeconds(delayLaunch);
            
            Launch();
        }

        reflectionWall2Tag = reflectionWall2.tag;

        

    }

    private void Update()
    {
        

        //Aceleracion de la bola
        velX = rb.linearVelocity.x;
        velY = rb.linearVelocity.y;

        timer += Time.deltaTime;
        timerNew = timer * aceleracion;

        if (velX > 0 && velY > 0)
        {
            rb.linearVelocity = new Vector2(velX + timerNew, rb.linearVelocity.y + timerNew);
        }

        if (velX < 0 && velY > 0)
        {
            rb.linearVelocity = new Vector2(velX - timerNew, rb.linearVelocity.y + timerNew);
        }

        if (velX < 0 && velY < 0)
        {
            rb.linearVelocity = new Vector2(velX - timerNew, rb.linearVelocity.y - timerNew);
        }

        if (velX > 0 && velY < 0)
        {
            rb.linearVelocity = new Vector2(velX + timerNew, rb.linearVelocity.y - timerNew);
        }

        //Raycast section        

        Vector2 origin = transform.position;
        Vector2 hitDirection = new Vector2(velX, velY);
        Vector2 normHitDirection = hitDirection.normalized;

        

        for (int i = 0; i < maxReflexions; i++)
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(origin, normHitDirection, maxRayDistance);

            if (hit.collider != null)
            {
                Debug.DrawRay(origin, normHitDirection * hit.distance, Color.red);
                Vector2 reflectDirection = Vector2.Reflect(normHitDirection, hit.normal);
                origin = hit.point;
                normHitDirection = reflectDirection;

                if (hit.collider.CompareTag(reflectionWall2Tag))
                {
                    hitPos = hit.point;
                    break;                    
                }
            } 
        }        
    } 
        
       
   
    

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(velocidad * x, velocidad * y);
        
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;        

        //Delay launch reset
        StartCoroutine(CallMethodAfterDelay());
        IEnumerator CallMethodAfterDelay()
        {
            yield return new WaitForSeconds(delayLaunch);
            Launch();
        }

        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            bounceSound.Play();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            float randomChange = Random.Range(-1f, 1f);            
            Vector2 force = new Vector2(0f, randomChange * forceMultiplier);
            rb.AddForce(force, ForceMode2D.Impulse);

        }
    }   
}
