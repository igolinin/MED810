using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRepresentation : MonoBehaviour
{
    public Material[] Materials;
    public GameObject Control;
    public PhysicMaterial[] physicmatierals;
    public Material[] SurMaterials;
    public GameObject Planet;
    public bool DifferentSize;
    public float[] PlanetSize;
    public bool[] trigger;
    public int Num=0;
    int i;
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Num+1) != Control.GetComponent<ScreenControl>().PlanetN && Control.GetComponent<ScreenControl>().PlanetN!=0)
        {
                ChangeSpheres();

            Num = Control.GetComponent<ScreenControl>().PlanetN;
            if (DifferentSize)
            {
                ChangeSize();
            }
            
        }
        

    }

    void ChangeSpheres()
    {
        Num = Control.GetComponent<ScreenControl>().PlanetN-1;
        gameObject.GetComponent<Renderer>().material = Materials[Num];
    }


    public void Fil(int a)
    {
        gameObject.GetComponent<Renderer>().material.color = colors[a];
    }

    void ChangeSize()
    {
        float scale = PlanetSize[Num - 1];
        Planet.transform.localScale = new Vector3(1.7f * scale, 1.7f * scale, 1.7f * scale);
    }
}
