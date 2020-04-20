using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screencontol : MonoBehaviour
{

    private int CurrentScreen = 1;
    private int NextDot;
    public GameObject NextPosition;
    private bool OnMove = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
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
}
