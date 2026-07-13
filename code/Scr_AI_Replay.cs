using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_AI_Replay : MonoBehaviour
{
    public void AIreplay() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AI_PressSpace");
        
    }

    public void AIback()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        
    }

}
