using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Quit Game
    public void quitApp()
    {
        Application.Quit();
        Debug.Log("Game is exiting");   //Check if quit is triggered
    }


}
