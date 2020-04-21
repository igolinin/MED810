using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Obj2_MouseMove : MonoBehaviour
{
    [SerializeField]
    public Transform ObjectPlace;

    private Vector2 initalPos;
    private Vector3 initalScale;
    private float deltaX, deltaY;

    public static bool locked = false;
    public GameObject Stage1Ligth;
    public GameObject Stage2Light;
    private Vector2 mosePos;
    // Start is called before the first frame update


    void Start()
    {
        initalPos = transform.position;
        initalScale = transform.localScale;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        mosePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);



    }
    void OnMouseDown()
    {
        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mosePos) && !locked)
        {
            deltaX = mosePos.x - transform.position.x;
            deltaY = mosePos.y - transform.position.y;
            Debug.Log("hello Touch");
        }
    }



    void OnMouseDrag()
    {
        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mosePos) && !locked)
        {
            transform.position = new Vector2(mosePos.x - deltaX, mosePos.y - deltaY);
        }
    }


    void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - ObjectPlace.position.x) <= 1f &&
            Mathf.Abs(transform.position.y - ObjectPlace.position.y) <= 1f && !locked)
        {
            transform.DOMove(new Vector2(ObjectPlace.position.x, ObjectPlace.position.y), 0.7f);
            locked = true;
            Stage2Light.SetActive(true);
            Stage1Ligth.SetActive(false);
            Debug.Log("Object Placed");

        }
        else
        {
            if (!locked)
            {
                transform.DOScale(new Vector3(initalScale.x, initalScale.y, initalScale.z), 1);
                transform.DOMove(new Vector2(initalPos.x, initalPos.y), 0.5f);

            }


        }
    }
}
