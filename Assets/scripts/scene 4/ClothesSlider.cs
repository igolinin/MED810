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
    public GameObject next;

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
    }

    private void Start()
    {
        temp = planet.GetComponent<ChoosenPlanet>().Temprature;
        
    }
    private void Update()
    {
        if (temp>60)
        {
            if (Current==4)
            {
                next.SetActive(true);
            }
            else
            {
                next.SetActive(false);
            }
        }
    }

}
