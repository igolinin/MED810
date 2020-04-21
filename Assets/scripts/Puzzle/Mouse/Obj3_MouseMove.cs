using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Obj3_MouseMove : MonoBehaviour
{
    [SerializeField]
    private Transform ObjectPlace;

    private Vector2 initalPos;
    private float deltaX, deltaY;

    public static bool locked;

    private Vector2 mousePos;


    void Start()
    {
        initalPos = transform.position;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);



    }
    void OnMouseDown()
    {
        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
        {
            deltaX = mousePos.x - transform.position.x;
            deltaY = mousePos.y - transform.position.y;
            Debug.Log("hello Touch");
        }
    }



    void OnMouseDrag()
    {
        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
        {
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }
    }


    void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - ObjectPlace.position.x) <= 1f &&
            Mathf.Abs(transform.position.y - ObjectPlace.position.y) <= 1f)
        {
            transform.DOMove(new Vector2(ObjectPlace.position.x, ObjectPlace.position.y), 0.7f);
            locked = true;

            Debug.Log("Object Placed");

        }
        else
        {
            transform.DOMove(new Vector2(initalPos.x, initalPos.y), 0.5f);

        }
    }
}
