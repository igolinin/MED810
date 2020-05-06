using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Consent : MonoBehaviour
{
    public ToggleGroup agree;
    public ToggleGroup education;
    public ToggleGroup gender;
    public InputField age;

    public DataShare Data;

    

    public void onSubmit(){
        collectData();
        SceneManager.LoadScene("Earth");
    }

    private void collectData(){
        DataShare.consent = ActiveToggle(agree);
        DataShare.education = ActiveToggle(education);
        DataShare.gender = ActiveToggle(gender);
        DataShare.age = age.text; 
    }
    private string ActiveToggle(ToggleGroup group){
        Debug.Log("start");
       Toggle toggle = group.ActiveToggles().FirstOrDefault(tg => tg.isOn == true);
       Debug.Log(group.GetComponentInChildren<Text>().text+toggle.name);
       return toggle.name;
   }
    
}