using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
   

    void Update ()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Debug.Log("Resuming");
                Resume();
            }
            else
            {
                Debug.Log("Pausing");
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
     public  void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
    public void LoadOpt()
    {
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
