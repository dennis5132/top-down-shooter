using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void sceneswitch()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitgame()
    {
        Application.Quit();
    }
    public void controls()
    {
        SceneManager.LoadScene("controls");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("startMenu");
    }
    public void winmenu()
    {
        SceneManager.LoadScene("winMenu");
    }
    public void credits()
    {
        SceneManager.LoadScene("credits");
    }
}