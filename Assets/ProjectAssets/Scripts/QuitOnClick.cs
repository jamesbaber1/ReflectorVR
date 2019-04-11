using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Quit Game
    public void Quit()
    {
        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = False;
        #else
          Application.Quit();
        #endif
    }

}
