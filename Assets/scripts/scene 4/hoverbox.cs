﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverbox : MonoBehaviour
{
    SpriteRenderer rend;
    Color c;
    public ScreenControl Control;
    public bool Found;
    public GameObject Planet;

    void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

    }
    void OnMouseEnter()
    {
        Found = Planet.GetComponent<ChoosenPlanet>().found;
        if (Found)
        {
            StartCoroutine("FadeIn");
        }
        
    }

    void OnMouseExit()
    {
        if (Found)
        {
            StartCoroutine("FadeOut");
        }
        
    }

    private void OnMouseDown()
    {
        if (Found)
        {
            Control.NextButton();
            Planet.GetComponent<ChoosenPlanet>().choose();
        }
        
    }

    IEnumerator FadeIn()
    {
        for (float f=0.05f; f<= 0.4f; f += 0.10f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 0.4f; f > 0.0f; f -= 0.10f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
