using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Obj_2_move : MonoBehaviour
{

    [SerializeField]
    private Transform ObjectPlace;

    private Vector2 initalPos;

    private float deltaX, deltaY;

    public static bool locked;
    public GameObject Stage2Light;
    public GameObject Stage1Light;


    // Start is called before the first frame update
    void Start()
    {
        initalPos = transform.position;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))

                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        GameControl.info2Close = false;
                          

                    break;



                case TouchPhase.Moved:

                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
        
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);

                break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - ObjectPlace.position.x) <= 1f &&
                        Mathf.Abs(transform.position.y - ObjectPlace.position.y) <= 1f)
                    {
                        transform.DOMove(new Vector2(ObjectPlace.position.x, ObjectPlace.position.y), 0.3f);
                        locked = true;
                        Stage2Light.SetActive(true);
                        Stage1Light.SetActive(false);
                        Debug.Log("Object2 placed");
                    }
                    else
                    {
                        transform.DOMove(new Vector2(initalPos.x, initalPos.y), 0.5f);
                    }
                    break;


            }
        }

    }
}
