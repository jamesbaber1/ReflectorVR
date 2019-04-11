using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    //Scene Manager
    public void LoadScene(int level){
      SceneManager.LoadScene(level);
    }
}
