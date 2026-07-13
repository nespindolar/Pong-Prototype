using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Replay : MonoBehaviour
{
    public void replay() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PressSpace");
        
    }

    public void back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        
    }

}
