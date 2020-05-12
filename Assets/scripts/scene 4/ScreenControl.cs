using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ScreenControl : MonoBehaviour
{

    public int CurrentScreen = 0;
    private int CurrentDot = 1;
    public GameObject NextPosition;
    public GameObject CurDot;
    public bool OnMove = false;
    public Color C1;
    public Color C2;
    public GameObject[] icons;
    public bool try_again = false;
    public int PlanetN;
    public TextMeshProUGUI count;
    private int FoundCount;
    public GameObject Catalog;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI info;
    public string[] explenations;
    public int i = 0;
    public string PlanetName;
    public Slider OrbitSlider;
    bool textCheck = false;


    // Start is called before the first frame update
    void Start()
    {
        string DotName = "Dot" + CurrentDot.ToString();
        CurDot = GameObject.Find(DotName);
        Title.text = "";
        info.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (FoundCount != S3toS4.counter)
        {
            FoundCounter();
        }

        if (OnMove)
        {
            MoveCamera();
        }

        Instruction();

    }

    public void NextButton()
    {
        CurrentScreen += 1;
        SetTarget();

    }

    public void BackButton()
    {
        if (CurrentScreen == 1)
        {
            PlanetN = 0;
        }
        CurrentScreen -= 1;
        SetTarget();
    }

    public void SetTarget()
    {
        string NextScreenName = "CheckPoint" + CurrentScreen.ToString();
        if (try_again && (CurrentScreen == 2 || CurrentScreen == 5 || CurrentScreen == 7))
        {
            NextScreenName = NextScreenName + "Wrong";
        }

        NextPosition = GameObject.Find(NextScreenName);
        OnMove = true;
    }

    void MoveCamera()
    {
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, NextPosition.transform.position, 0.1f);
        transform.position = SmoothedPosition;
        float distancex = Mathf.Abs(transform.position.x - NextPosition.transform.position.x);
        float distancey = Mathf.Abs(transform.position.y - NextPosition.transform.position.y);
        if (distancex < 0.5f && distancey < 0.5f)
        {
            OnMove = false;
        }

    }

    public void ChangeDot()
    {
        CurDot.GetComponent<Image>().color = C2;
        CurrentDot += 1;
        string DotName = "Dot" + CurrentDot.ToString();
        CurDot = GameObject.Find(DotName);
        CurDot.GetComponent<Image>().color = C1;
    }

    public void BackDot()
    {
        CurDot.GetComponent<Image>().color = C1;
        CurrentDot -= 1;
        string DotName = "Dot" + CurrentDot.ToString();
        CurDot = GameObject.Find(DotName);
        CurDot.GetComponent<Image>().color = C2;
    }

    public void wrong()
    {
        try_again = true;
        SetTarget();
    }

    public void AddIcon(int a)
    {
        icons[a].GetComponent<Image>().color = C1;
    }

    public void Try_again_button()
    {
        try_again = false;
        SetTarget();
    }

    void FoundCounter()
    {
        FoundCount = S3toS4.counter;
        if (FoundCount == 1)
        {
            count.text = "0" + FoundCount.ToString() + " Planet";
        }
        else if (FoundCount > 9)
        {
            count.text = FoundCount.ToString() + " Planets";
        }
        else
        {
            count.text = "0" + FoundCount.ToString() + " Planets";
        }
    }

    public void Answer()
    {
        int a = Catalog.GetComponent<ScrollControl>().AnswerNum + 1;
        if (a == PlanetN)
        {
            NextButton();
        }
        else
        {
            wrong();
        }
    }

    void Instruction()
    {
        Debug.Log("first");
        int j = i;
        if (CurrentScreen < 2 || CurrentScreen == 3 || CurrentScreen > 7 || try_again || OnMove == true)
        {
            i = 0;
        }
        else if (CurrentScreen >3 && CurrentScreen <8)
        {
            i = CurrentScreen - 2;
        }
        else if (CurrentScreen == 2)
        {
            i = 1;
        }

        if (j != i)
        {
            if (i == 0)
            {
                Title.text = "";
            }
            else if (i==1)
            {
                Title.text = "Comparison of "+ PlanetName+" and Earth";
            }
            else if(i==2)
            {
                Title.text = "Exploring "+PlanetName;
            }
            else if(i==3)
            {
                Title.text = "Find out what’s "+ PlanetName + " temperature";
            }
            else if (i==4)
            {
                Title.text = "Find out what’s "+PlanetName+"’s Gravity and Surface type";
            }
            else if(i==5)
            {
                Title.text = "What kind of planet did you find?";
            }

            info.text = explenations[i];
        }

        if (textCheck == false)
        {
            if (OrbitSlider.value == 1.00f)
            {
                info.text = "Stop the satellite when it completes one orbit of " + PlanetName;
                textCheck = true;
            }
        }


    }




}
