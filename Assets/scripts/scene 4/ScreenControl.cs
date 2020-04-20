using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ScreenControl : MonoBehaviour
{

    private int CurrentScreen = 0;
    private int CurrentDot = 1;
    public GameObject NextPosition;
    public GameObject CurDot;
    private bool OnMove = false;
    public Color C1;
    public Color C2;
   
    // Start is called before the first frame update
    void Start()
    {
        string DotName = "Dot" + CurrentDot.ToString();
        CurDot = GameObject.Find(DotName);
    }

    // Update is called once per frame
    void Update()
    {
       if (OnMove)
        {
            MoveCamera();
        }
    }

    public void NextButton()
    {
        CurrentScreen += 1;
        SetTarget();

    }

    public void BackButton()
    {
        CurrentScreen -= 1;
        SetTarget();
    }

    void SetTarget()
    {
        string NextScreenName = "CheckPoint" + CurrentScreen.ToString();
        NextPosition = GameObject.Find(NextScreenName);
        OnMove = true;
    }

    void MoveCamera()
    {
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, NextPosition.transform.position, 0.1f);
        transform.position = SmoothedPosition;
        if (transform.position==NextPosition.transform.position)
        {
            OnMove = false;
        }
    }

    public void ChangeDot()
    {
        CurDot.GetComponent<Image>().color = C1;
        CurrentDot += 1;
        string DotName = "Dot" + CurrentDot.ToString();
        CurDot = GameObject.Find(DotName);
        CurDot.GetComponent<Image>().color = C2;
    }

    public void BackDot()
    {
        CurDot.GetComponent<Image>().color = C2;
        CurrentDot -= 1;
        string DotName = "Dot" + CurrentDot.ToString();
        CurDot = GameObject.Find(DotName);
        CurDot.GetComponent<Image>().color = C1;
    }


}
