using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class surveyUploader : MonoBehaviour
{
    public ToggleGroup group1;
    public ToggleGroup group2;
    public ToggleGroup group3;
    public ToggleGroup group4;
    public DataShare Data;
    public string Url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfWc7uiPmc-9vnhsqhR-FiIqc7ZgV40AQQB1IYLnaK6tVU7yQ/formResponse";
    
    IEnumerator Post(){
         List<IMultipartFormSection> form = new  List<IMultipartFormSection>();
       form.Add(new MultipartFormDataSection("entry.234539220", DataShare.consent));
        form.Add(new MultipartFormDataSection("entry.611454284", DataShare.education));
        form.Add(new MultipartFormDataSection("entry.27007606", DataShare.gender));
        form.Add(new MultipartFormDataSection("entry.996174683", DataShare.age)); 
        form.Add(new MultipartFormDataSection("entry.373831352", DataShare.again1));
        form.Add(new MultipartFormDataSection("entry.13445190", DataShare.again2));
        form.Add(new MultipartFormDataSection("entry.1415968862", DataShare.again3));
        form.Add(new MultipartFormDataSection("entry.717642429", DataShare.again4)); 
       form.Add(new MultipartFormDataSection("entry.1306644959", ActiveToggle(group1)));
       form.Add(new MultipartFormDataSection("entry.1639978155", ActiveToggle(group2)));
       form.Add(new MultipartFormDataSection("entry.1356009003", ActiveToggle(group3)));
       form.Add(new MultipartFormDataSection("entry.939145730", ActiveToggle(group4)));
       UnityWebRequest  WWW = UnityWebRequest.Post(Url, form);
       yield return WWW.SendWebRequest();
   }
   private void collectData(){
        DataShare.imi1 = ActiveToggle(group1);
        DataShare.imi2 = ActiveToggle(group2);
        DataShare.imi3 = ActiveToggle(group3);
        DataShare.imi4 = ActiveToggle(group4);
    }
    public void onSubmit(){
       //Debug.Log(ActiveToggle(group1));
       //answer = activeToggle();
       //StartCoroutine(Post());
       collectData();
       SceneManager.LoadScene("Final");

   }
   private string ActiveToggle(ToggleGroup group){
       Toggle toggle = group.ActiveToggles().FirstOrDefault(tg => tg.isOn == true);
       Debug.Log(group.GetComponentInChildren<Text>().text+toggle.name);
       return toggle.name;
   }
}
