using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class groupManager : MonoBehaviour
{
   public Toggle isYes;
   public Toggle isMaybe;
   public Toggle isNo;
   private string answer;
   [SerializeField] 
   private string Url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfC8tqQ1gVu66pzWqLbgCIKznq6QQRnUNtV-Qh5xYzdyR2h6g/formResponse";
   public DataShare Data;
  

   
    void saveData(int sceneNumber, string active){
        if(sceneNumber == 1){
            DataShare.again1 = active;
        }else if(sceneNumber == 2){
            DataShare.again2 = active;
        }else if(sceneNumber == 3){
            DataShare.again3 = active;
        }else if(sceneNumber == 4){
            DataShare.again4 = active;
        }
        
    }

   public string activeToggle(){
       if(isYes.isOn){
           return "Yes";
       }else if(isMaybe.isOn){
           return "Maybe";
       }else if(isNo.isOn){
           return "No";
       }
       return "";

   }
   
   public void onSubmit(){
       //Debug.Log("Active toggle"+ activeToggle());
       //Debug.Log("Latest scene global"+ DataShare.latestScene);
       //string active = activeToggle();
       saveData (DataShare.latestScene, activeToggle());
       
       if(DataShare.latestScene <= 3){
           SceneManager.LoadScene(++DataShare.latestScene);
       }else{
           SceneManager.LoadScene("IMI");
       }
        

   }

}
