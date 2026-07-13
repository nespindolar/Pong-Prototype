using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_PlayMode : MonoBehaviour
{
    public static float easySpeed = 9f;
    public static float mediumSpeed = 11f;
    public static float hardSpeed = 13.5f;


    public void P1vsP2()
    {
        SceneManager.LoadScene("PressSpace");
    }

    public void easy()
    {
        Scr_AI.vel = easySpeed;
        SceneManager.LoadScene("AI_PressSpace");
    }

    public void medium()
    {
        Scr_AI.vel = mediumSpeed;
        SceneManager.LoadScene("AI_PressSpace");
    }

    public void hard()
    {
        Scr_AI.vel = hardSpeed;
        SceneManager.LoadScene("AI_PressSpace");
    }
}
