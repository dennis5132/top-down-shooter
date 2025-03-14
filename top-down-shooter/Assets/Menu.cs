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
}