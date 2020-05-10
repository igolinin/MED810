using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesSlider : MonoBehaviour
{
    public GameObject[] Characters;
    public float Current;
    public Slider slider;
    public int max;
    public GameObject planet;
    public bool correct;
    public int temp;
    public ScreenControl Nextscreen;
    public float TempGroup;
    public Slider Slider2;
    float Diff;


    // Start is called before the first frame update


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

    private void Start()
    {
        temp = planet.GetComponent<ChoosenPlanet>().Temprature;
        if (temp > 1000)
        {
            TempGroup = 4;
        }
        else if (temp >150)
        {
            TempGroup = 3;
        }
        else if (temp > 15)
        {
            TempGroup = 2;
        }
        else if ( temp> (-100))
        {
            TempGroup = 1;
        }
        else
        {
            TempGroup = 0;
        }
        ChangeValue();
    }


    void ChangeValue()
    {
        Diff = Current - TempGroup;
        Slider2.value = 0.44f + (Diff * 0.11f);
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
