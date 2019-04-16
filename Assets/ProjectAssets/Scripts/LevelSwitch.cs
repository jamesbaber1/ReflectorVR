using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    public int currLevel = 0;

    public string[] levelNames = new string[2] {"introScene", "mainScene"};

    static LevelSwitch s = null;

    // Initialization
    void start () {
      if (s == null)
        s = this;
      else
        Destroy(this.gameObject);

      DontDestroyOnLoad(this.gameObject);
    }

    // Update called once per frame
    void Update () {
      if (Input.anyKeyDown){
        currLevel = (currLevel + 1) % 2; // Next level
        //Steam.Begin(levelNames[currLevel]);
        //SteamVR_LoadLevel.Begin(levelNames[currLevel]);
      }
    }
}
