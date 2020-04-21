using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class MoonCycle : MonoBehaviour
{
    public Slider slider;
    public Material mat1;
    private Material mat2;    // Start is called before the first frame update
    void Start()
    {
        mat2 = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, slider.value-180);
        transform.LookAt(Vector3.zero);
        if(slider.value >180)
        {
            RenderSettings.skybox = mat1;
        }else
        {

            RenderSettings.skybox = mat2;
        }
    }
}