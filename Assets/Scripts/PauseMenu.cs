using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;

    public string mainMenu;

    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("p"))
        {
            isPaused = !isPaused;
        }
    }
    public void Resume()
    {
        isPaused = false;
    }
        public void Quit()
    {
        Application.Quit();
    }
}


   
   

