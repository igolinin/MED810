using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollControl : MonoBehaviour
{
    public Vector3 PlaceHolder;
    public GameObject[] types;
    private bool isDrag= false;
    private Vector3[] positions;
    private int closestN;



    private void Start()
    {
        PlaceHolder = types[0].transform.position;

    }
}
