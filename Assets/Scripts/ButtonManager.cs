using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource ClickSound;
    public AudioSource MainSound;

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
        ClickSound.Play();
        MainSound.Stop();
    }
    public void ExitGameBtn()
    {
        ClickSound.Play();
        MainSound.Stop();
        Application.Quit();
      
    }
}
