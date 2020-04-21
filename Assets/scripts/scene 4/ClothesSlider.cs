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

}
