using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SunCycle : MonoBehaviour
{


    public Slider slider;
    public Material mat1;
    private Material mat2;
    private float exposure = 0;

    private bool switchSky =false;

    void Start()
    {
        mat2 = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3( slider.value,0,0);

        if (slider.value > 100)
        {
            if(switchSky == false)
            {
                StartCoroutine(FadeInCoroutine());
                exposure = 0;
            }

            RenderSettings.skybox = mat1;
           
            switchSky = true;
        }
        else
        {
            if(switchSky)
            {

                StartCoroutine(FadeOutCoroutine());
            }
            RenderSettings.skybox = mat2;
            mat1.SetFloat("_Exposure", 0);
            switchSky = false;
        }
    }

    IEnumerator FadeInCoroutine()
    {


        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.1f);       
            exposure += 0.1f;
            mat1.SetFloat("_Exposure", exposure);
        }

    }

    IEnumerator FadeOutCoroutine()
    {


        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.1f);
            exposure -= 0.1f;
            mat1.SetFloat("_Exposure", exposure);
        }

    }
}


