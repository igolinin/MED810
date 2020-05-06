using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class DataShare : MonoBehaviour
{
    public static int latestScene;
    

    public static string consent;
    public static string education;
    public static string gender;
    public static string again1;
    public static string again2;
    public static string again3;
    public static string again4;
    public static string imi1;
    public static string imi2;
    public static string imi3;
    public static string imi4;
    public static string final1;
    public static string final2;
    public static string age;
     
     void Start()
     {
         
         Scene scene = SceneManager.GetActiveScene();
         Debug.Log(consent+",  "+education+",  "+gender+",  "+again1+",  "+again2+",  "+again3+",  "+again4+",  "+imi1+",  "+imi2+",  "+imi3+",  "+imi4+",  "+final1+",  "+final2+",  "+"!!!");
         
         if (scene.buildIndex != 6&&scene.buildIndex != 5){
            latestScene = scene.buildIndex;
         }
            
         DontDestroyOnLoad(this);
     }
}
/*
form.Add(new MultipartFormDataSection("entry.234539220", ActiveToggle(group1))); consent
form.Add(new MultipartFormDataSection("entry.996174683", ActiveToggle(group1))); age
form.Add(new MultipartFormDataSection("entry.611454284", ActiveToggle(group1))); education
form.Add(new MultipartFormDataSection("entry.373831352", ActiveToggle(group1))); Again 1
form.Add(new MultipartFormDataSection("entry.13445190", ActiveToggle(group1))); Again 2
form.Add(new MultipartFormDataSection("entry.1415968862", ActiveToggle(group1))); Again 3
form.Add(new MultipartFormDataSection("entry.717642429", ActiveToggle(group1))); Again 4
form.Add(new MultipartFormDataSection("entry.1169282443", ActiveToggle(group1)));
form.Add(new MultipartFormDataSection("entry.234539220", ActiveToggle(group1)));

*/