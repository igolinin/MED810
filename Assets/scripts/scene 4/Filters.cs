﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filters : MonoBehaviour
{
    public bool[] activated;
    public GameObject Next_Button;
    public Color[] filters;
    public Renderer Planet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool all_true = true;
        for (int i = 0; i < activated.Length; i++)
        {
            if (activated[i] == false)
            {
                all_true = false;
            }
        }
        if (all_true == true)
        {
            Next_Button.SetActive(true);
        }
    }

    public void filter_selected(int number)
    {
        if (activated[number - 1] == false)
        {
            activated[number - 1] = true;
        }
    }

    public void ChangeFilter (int a)
    {
        Debug.Log(a);
        Debug.Log(Planet.material.GetColor("_BaseColor"));
        Planet.material.SetColor("_BaseColor", filters[a]);
        Debug.Log(Planet.material.GetColor("_BaseColor"));
    }


}
