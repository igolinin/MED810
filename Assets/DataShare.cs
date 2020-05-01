using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataShare : MonoBehaviour
{
    public static int latestScene;
     
     void Start()
     {
         Scene scene = SceneManager.GetActiveScene();
         Debug.Log("latest scene" + latestScene +"current scene" + scene.buildIndex);
         
         if (scene.buildIndex != 5&&scene.buildIndex != 4){
            latestScene = scene.buildIndex;
         }
            
         DontDestroyOnLoad(this);
     }
}
