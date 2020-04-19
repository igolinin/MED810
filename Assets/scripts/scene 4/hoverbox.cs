using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverbox : MonoBehaviour
{
    SpriteRenderer rend;
    Color c;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

    }
    void OnMouseEnter()
    {
        Debug.Log("hello");
        StartCoroutine("FadeIn");
    }

    void OnMouseExit()
    {
        Debug.Log("bye");
    }

    IEnumerator FadeIn()
    {
        for (float f=0.05f; f<= 0.4f; f += 0.05f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
