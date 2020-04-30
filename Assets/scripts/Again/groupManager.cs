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
  

   IEnumerator Post(string answer, int scene){
       List<IMultipartFormSection> form = new List<IMultipartFormSection>();
       form.Add(new MultipartFormDataSection("entry.953809921", answer));
       form.Add(new MultipartFormDataSection("entry.636757715", scene.ToString()));
       UnityWebRequest  WWW = UnityWebRequest.Post(Url, form);
       yield return WWW.SendWebRequest();
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
       Debug.Log("Active toggle"+ activeToggle());
       Debug.Log("Latest scene global"+ DataShare.latestScene);
       answer = activeToggle();
       int nextScene = ++DataShare.latestScene;
       StartCoroutine(Post(answer, nextScene));
       if(nextScene <= 3){
           SceneManager.LoadScene(nextScene);
       }else{
           SceneManager.LoadScene("IMI");
       }
        

   }

}
