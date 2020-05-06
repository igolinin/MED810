using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableButton : MonoBehaviour
{
    public GameObject btn;
    public CameraController2 cc;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.counter.text.Equals("Exoplanets found:0"))
        {
            
        }

        
    }
}
