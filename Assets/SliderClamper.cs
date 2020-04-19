using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderClamper : MonoBehaviour
{

    [SerializeField] private Slider slider;
    
    [SerializeField] private float minClamp=0;
    [SerializeField] private float maxClamp=1;

    private void Start()
    {
        slider.value = minClamp;
    }

    public void ValueChange()
    {
        if (slider.value < minClamp)
        {
            slider.value = minClamp;
        }

        if (slider.value > maxClamp)
        {
            slider.value = maxClamp;
        }
    }


    
}
