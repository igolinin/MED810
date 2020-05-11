using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetRepresentation : MonoBehaviour
{
    public Material[] Materials;
    public GameObject Control;
    public int Num;
    public Color[] colors;
    public string[] Types;
    public bool isLast;
    public TextMeshProUGUI theType;
    public GameObject Planet;
    public bool DifferentSize;
    public float[] PlanetSize;

    // Start is called before the first frame update
    void Start()
    {
        Num = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Num + 1) != Control.GetComponent<ScreenControl>().PlanetN && Control.GetComponent<ScreenControl>().PlanetN != 0)
        {
            ChangeSpheres();
            if (DifferentSize)
            {
                ChangeSize();
            }

        }



    }

    void ChangeSpheres()
    {
        Num = Control.GetComponent<ScreenControl>().PlanetN - 1;
        gameObject.GetComponent<Renderer>().material = Materials[Num];
        if (isLast)
        {
            theType.text = "A new " + Types[Num] + " Planet";
        }

    }

    void ChangeSize()
    {
        float scale = PlanetSize[Num];
        Planet.transform.localScale = new Vector3(1.7f * scale, 1.7f * scale, 1.7f * scale);
    }

    public void Fil(int a)
    {
        gameObject.GetComponent<Renderer>().material.color = colors[a];
    }
}