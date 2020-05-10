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
    public bool IsSurface;
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
            if (IsSurface)
            {
                ChangeSurface();
            }
            else
            {
                ChangeSpheres();
            }

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

    void ChangeSurface()
    {
        if (Num == 2 || Num == 3 || Num == 7 || Num == 8)
        {
            //Gas planets
            i = 0;
        }
        else if (Num == 1 || Num == 4)
        {
            //Ice planets
            i = 1;
        }
        else if (Num==5)
        {
            //Lava
            i = 2;
        }
        else if(Num == 9)
        {
            //water
            i = 3;
        }
        else
        { //earth
            i = 4;
        }

        BoxCollider a = gameObject.GetComponent<BoxCollider>();
        a.material = physicmatierals[i];
        a.isTrigger = trigger[i];
        gameObject.GetComponent<MeshRenderer>().material = SurMaterials[i];
    }


    void ChangeSize()
    {
        float scale = PlanetSize[Num - 1];
        Planet.transform.localScale = new Vector3(1.7f * scale, 1.7f * scale, 1.7f * scale);
    }
    public void Fil(int a)
    {
        gameObject.GetComponent<Renderer>().material.color = colors[a];
    }
}
