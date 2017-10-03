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
        if (isPaused)                             // If isPaused is true, time scale will go to zero and pause canvas will be true.
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);   // If isPaused is false, time scale will go to one and pause canvas will be flase.
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("p"))             // isPused will turn true or false when P is hit by the player. 
        {
            isPaused = !isPaused;
        }
    }
    public void Resume()                      // Player can click on resume button to unpause the game.
    {
        isPaused = false;
    }
        public void Quit()                   // Player can clck on quit button to shut down the game application. 
    {
        Application.Quit();
    }
}


   
   

