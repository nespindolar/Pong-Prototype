using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_GameManager : MonoBehaviour
{
    public GameObject ball;

    public GameObject player1;
    public Text textPlayer1;
    public GameObject charger1;    

    public GameObject player2;
    public Text textPlayer2;
    public Text textChargerPlayer2;    

    public GameObject goal1;
    public GameObject goal2;

    public Text spaceText;

    public GameObject ReplayPanelUI;
    public GameObject P1Wins;
    public GameObject P2Wins;
    public bool PressPause = true;    

    public static bool GameIsPaused = false;
    public GameObject PausePanelUI;

    public float maxPoints;    

    private int player1score;
    private int player2score;

    public bool AIGame;

    private void Start()
    {
        ReplayPanelUI.SetActive(false);
        PausePanelUI.SetActive(false);
        P1Wins.gameObject.SetActive(false);
        P2Wins.gameObject.SetActive(false);
                
    }

    private void Update()
    {
        //Shows replay panel when maxPoints are scored
        if (player1score >= maxPoints && PressPause == true)
        {
            ReplayPanelUI.SetActive(true);
            P1Wins.SetActive(true);
            Time.timeScale = 0f;
            
            
        }

        else if (player2score >= maxPoints && PressPause == true)
        {
            ReplayPanelUI.SetActive(true);
            P2Wins.SetActive(true);
            Time.timeScale = 0f;
            
        }

        //Pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();                                
            }

            else
            {
                Pause();                               
            }
        }

        
        void Pause()
        {
            PressPause = false;
            PausePanelUI.SetActive(true);
            ReplayPanelUI.SetActive(false);
            P1Wins.gameObject.SetActive(false);
            P2Wins.gameObject.SetActive(false);

            Time.timeScale = 0f;
            GameIsPaused = true;                        
        }
        
    }

    public void Resume()
    {
        PressPause = true;
        PausePanelUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Player1Scored()
    {
        player1score++;
        textPlayer1.text = player1score.ToString();

        ResetPosition();
    }
    public void Player2Scored()
    {
        player2score++;
        textPlayer2.text = player2score.ToString();

        ResetPosition();
    }

    private void ResetPosition()
    {
        if (AIGame)
        {
            ball.GetComponent<Scr_Ball>().Reset();
            player1.GetComponent<Scr_Players>().Reset();
            player2.GetComponent<Scr_AI>().Reset();
        }

        else
        {
            ball.GetComponent<Scr_Ball>().Reset();
            player1.GetComponent<Scr_Players>().Reset();
            player2.GetComponent<Scr_Players>().Reset();
        }
        
    }

}
