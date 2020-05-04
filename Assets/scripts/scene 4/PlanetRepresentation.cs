using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PlanetRepresentation : MonoBehaviour
{
    public Material[] Materials;
    public GameObject Control;
    public int Num=0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Num != Control.GetComponent<ScreenControl>().PlanetN)
        {
            Num = Control.GetComponent<ScreenControl>().PlanetN;
            gameObject.GetComponent<Renderer>().material = Materials[(Num-1)];
        }
        

    }
}
