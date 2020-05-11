using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClothesSlider : MonoBehaviour
{
    public GameObject[] Characters;
    public float Current;
    public Slider slider;
    public int max;
    public bool correct;
    public ScreenControl Nextscreen;
    public float TempGroup;
    public Slider Slider2;
    float Diff;
    float NewValue;
    bool oneTime = false;
    public GameObject[] Planets;
    int Num;


    // Start is called before the first frame update
    void Start()
    {
        Num = 20;
    }

    public void GetTemp(int temp)
    {
        if (temp > 1000)
        {
            TempGroup = 4;
        }
        else if (temp > 150)
        {
            TempGroup = 3;
        }
        else if (temp > 15)
        {
            TempGroup = 2;
        }
        else if (temp > (-100))
        {
            TempGroup = 1;
        }
        else
        {
            TempGroup = 0;
        }
        chracterSwitch();
    }



    public void chracterSwitch()
    {
        Current = slider.value;
        for (int i=0; i<max; i++)
        {
            if (i==Current)
            {
                Characters[i].SetActive(true);
            }
            else
            {
                Characters[i].SetActive(false);
            }
        }
        ChangeValue();
    }

    private void Update()
    {


        if (Slider2.value != NewValue)
        {
            Slider2.value = Mathf.Lerp(Slider2.value, NewValue, Time.deltaTime * 5f);
        }

        if (Nextscreen.PlanetN !=0)
        {
            if (Num+1!=Nextscreen.PlanetN)
            {
                Num = (Nextscreen.PlanetN-1);
                int a = Planets[Num].GetComponent<ChoosenPlanet>().Temprature;
                GetTemp(a);
            }
            if (oneTime == false)
            {
                slider.value = Random.Range(0, 5);
                Current = slider.value;
                if (Current != TempGroup)
                {
                    oneTime = true;
                }


            }
        }

    }


    void ChangeValue()
    {
        Diff = TempGroup-Current;
        NewValue = 0.44f + (Diff * 0.11f);
    }

    public void CheckAnswer()
    {
        if (Diff == 0)
        {
            Nextscreen.NextButton();
            Nextscreen.ChangeDot();
            Nextscreen.AddIcon(5);

        }

        else
        {
            Nextscreen.wrong();
        }
    }

}
