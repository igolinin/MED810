using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obj_1_move : MonoBehaviour
{


    [SerializeField]
    public Transform ObjectPlace;

    private Vector2 initalPos;
    private Vector3 initalScale;
    private float deltaX, deltaY;

    public GameObject primarySensor;

    public static bool locked = false;
    public GameObject Stage1Light;
    public GameObject Stage0Ligth;
    public  

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

        if( Input.touchCount >0 && !locked)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        transform.DOScale(new Vector3(0.1119435f, 0.1119435f, 0.1119435f), 0.7f);

                        transform.DOScale(primarySensor.transform.localScale, 0.7f);

                        Debug.Log("hello Touch");
                    }

                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }

                    break;

                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x - ObjectPlace.position.x) <= 1f &&
                        Mathf.Abs(transform.position.y - ObjectPlace.position.y) <= 1f) 
                    {
                        transform.DOMove( new Vector2(ObjectPlace.position.x, ObjectPlace.position.y), 0.7f);
                        locked = true;
                        Stage0Ligth.SetActive(false);
                        Stage1Light.SetActive(true);
                        Debug.Log("Object Placed");

                    }else{
                        transform.DOScale(new Vector3(initalScale.x,initalScale.y,initalScale.z),1);
                        transform.DOMove(new Vector2(initalPos.x, initalPos.y), 0.5f);

                    }
                     break;


            }
        }

    }
}
