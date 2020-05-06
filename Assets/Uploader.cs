using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class Uploader : MonoBehaviour
{
    public InputField final1;
    public InputField final2;

    public DataShare data;
    public string Url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfWc7uiPmc-9vnhsqhR-FiIqc7ZgV40AQQB1IYLnaK6tVU7yQ/formResponse";

    IEnumerator Post(){
        Debug.Log(DataShare.consent+"..."+DataShare.education+"..."+DataShare.gender+"..."+DataShare.again1+"..."+DataShare.again2+"..."+DataShare.again3+"..."+DataShare.again4+"..."+DataShare.imi1+"..."+DataShare.imi2+"..."+DataShare.imi3+"..."+DataShare.imi4+"..."+final1.text+"..."+final2.text+",  "+"!!!");
         List<IMultipartFormSection> form = new  List<IMultipartFormSection>();
       
        form.Add(new MultipartFormDataSection("entry.373831352", DataShare.again1));
        form.Add(new MultipartFormDataSection("entry.13445190", DataShare.again2));
        form.Add(new MultipartFormDataSection("entry.1415968862", DataShare.again3));
        form.Add(new MultipartFormDataSection("entry.717642429", DataShare.again4)); 
       form.Add(new MultipartFormDataSection("entry.1306644959", DataShare.imi1));
       form.Add(new MultipartFormDataSection("entry.1639978155", DataShare.imi2));
       form.Add(new MultipartFormDataSection("entry.1356009003", DataShare.imi3));
       form.Add(new MultipartFormDataSection("entry.939145730", DataShare.imi4));
       form.Add(new MultipartFormDataSection("entry.1169282443", final1.text));
       form.Add(new MultipartFormDataSection("entry.249996947", final2.text));
       form.Add(new MultipartFormDataSection("entry.234539220", DataShare.consent));
        form.Add(new MultipartFormDataSection("entry.611454284", DataShare.education));
        form.Add(new MultipartFormDataSection("entry.27007606", DataShare.gender));
        form.Add(new MultipartFormDataSection("entry.996174683", DataShare.age)); 
       UnityWebRequest  WWW = UnityWebRequest.Post(Url, form);
       yield return WWW.SendWebRequest();
   }
   public void onSubmit(){
       
       StartCoroutine(Post());
       Invoke("quit", 3);
      

   }
   public void quit(){
       Application.Quit();
   }
}
