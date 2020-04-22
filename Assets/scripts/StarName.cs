using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarName : MonoBehaviour
{
    public Text starName;
    public string starText;
    // Start is called before the first frame update
    void Start()
    {
        starName = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        starText = starName.text;
    }
}
