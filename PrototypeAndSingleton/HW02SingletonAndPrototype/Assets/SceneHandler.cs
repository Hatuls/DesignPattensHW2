using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    int startingSceneIndex=0;

   public static SceneHandler instance;
    void Start()
    {
      
        instance = this;
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadNextScene() {

        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
 
        startingSceneIndex++;

        Debug.Log("Level Loaded: " + (startingSceneIndex+1));

        if (startingSceneIndex >1)
        {
            startingSceneIndex = 0;
        }
      
        SceneManager.LoadScene(startingSceneIndex);

    }
}
