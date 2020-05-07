using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class ScrollControl : MonoBehaviour
{
    public UnityEngine.Vector3 PlaceHolder;
    public GameObject[] types;
    private bool isDrag=false;
    private float[] positions;
    public int closestN;
    public RectTransform panel;
    public float NormalDis;
    public GameObject[] dots;
    public Color C1;
    public Color C2;
    public int AnswerNum;



    private void Start()
    {
        PlaceHolder = types[0].transform.position;
        positions = new float[types.Length];
        NormalDis = Mathf.Abs(types[1].GetComponent<RectTransform>().anchoredPosition.x - types[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    private void Update()
    {
        CheckDistance();
        if (isDrag == false)
        {
            Magnet();
        }
        AnswerNum = types[closestN].GetComponent<PlanetType>().TypeNum;
        
    }

    void CheckDistance()
    {
        for (int i = 0; i<types.Length; i++)
        {
            positions[i] = Mathf.Abs(types[i].transform.position.x - PlaceHolder.x);
            if (positions[i]<positions[closestN])
            {
                closestN = i;
            }

        }
    }

    void Magnet()
    {
        float Anchor = closestN * (-NormalDis);
        float newPos = Mathf.Lerp(panel.anchoredPosition.x, Anchor, Time.deltaTime * 10f);
        UnityEngine.Vector2 FixedPosition = new UnityEngine.Vector2(newPos, panel.anchoredPosition.y);
        panel.anchoredPosition = FixedPosition ;
        ChangeDot();

    }

    public void StartDrag()
    {
        isDrag = true;
    }

    public void endDrag()
    {
        isDrag = false;
    }

    void ChangeDot()
    {
        for (int a = 0; a<dots.Length;a++)
        {
            if (a == closestN)
            {
                dots[a].GetComponent<SpriteRenderer>().color= C1;
            }
            else
            {
                dots[a].GetComponent<SpriteRenderer>().color = C2;
            }
                
        }
        
    }
}
