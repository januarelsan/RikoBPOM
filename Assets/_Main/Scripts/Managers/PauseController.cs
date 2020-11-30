using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gameIsPaused;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     gameIsPaused = !gameIsPaused;
        //     PauseGame();
        // }
    }

    public void PauseGame ()
    {
        gameIsPaused = ! gameIsPaused;
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            GameManager.Instance.SetIsPlaying(false);
        }
        else 
        {
            Time.timeScale = 1;
            GameManager.Instance.SetIsPlaying(true);
        }
    }

    public void SetPauseGame (bool value)
    {
        gameIsPaused = value;
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            GameManager.Instance.SetIsPlaying(false);
        }
        else 
        {
            Time.timeScale = 1;
            GameManager.Instance.SetIsPlaying(true);
        }
    }
}
