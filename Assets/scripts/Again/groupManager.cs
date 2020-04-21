using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class groupManager : MonoBehaviour
{
   public Toggle isYes;
   public Toggle isMaybe;
   public Toggle isNo;
   private string answer;
   [SerializeField] 
   private string Url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfC8tqQ1gVu66pzWqLbgCIKznq6QQRnUNtV-Qh5xYzdyR2h6g/formResponse";

   IEnumerator Post(string answer){
       WWWForm form =new WWWForm();
       form.AddField("entry.953809921", answer);
       byte[] rawData = form.data;
       WWW WWW = new WWW (Url, rawData);
       yield return WWW;
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
       Debug.Log(activeToggle());
       answer = activeToggle();
       StartCoroutine(Post(answer));

   }

}
