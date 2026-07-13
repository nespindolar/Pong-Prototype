using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Goal : MonoBehaviour
{
    public bool goal2;
    public GameObject gameManager;

    public AudioSource goalSound;

    public Text PlusOne1;
    public Text PlusOne2;

    public float timer = -1, tiempoEspera =1;
    

    public void Start()
    {
        goalSound = GetComponent<AudioSource>();
        PlusOne1.gameObject.SetActive(false);
        PlusOne2.gameObject.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0 && timer <0.1)// Check if this is efficient code
        {
            PlusOne1.gameObject.SetActive(false);
            PlusOne2.gameObject.SetActive(false);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))

          timer = tiempoEspera;
        
          goalSound.Play();
            

        if (goal2)
            {
                gameManager.GetComponent<Scr_GameManager>().Player1Scored();
                PlusOne1.gameObject.SetActive(true);
            }
                
                else
             {
                gameManager.GetComponent<Scr_GameManager>().Player2Scored();
                PlusOne2.gameObject.SetActive(true);
             }
    }
}
