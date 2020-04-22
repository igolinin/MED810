using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Obj1_MouseMove : MonoBehaviour
{

    [SerializeField]
    public Transform ObjectPlace;

    private Vector2 initalPos;
    private Vector3 initalScale;
    private float deltaX, deltaY;

    public GameObject primaryObjSize;

    public static bool locked = false;
    public GameObject Stage1Light;
    public GameObject Stage0Ligth;
    private Vector2 mosePos;
    // Start is called before the first frame update

    //This is a bugfix!!! Not good 
    public GameObject Lens;


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

            //This is a bugfix will fix later, there some interferancce with the collides i dont understand

            Lens.GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("HEJ");
            
            if ("PuzzleTelescope1"  != SceneManager.GetActiveScene().name)
            {
                transform.DOScale(new Vector3(0.1228481f, 0.1228481f, 0.1228481f), 0.5f);
            }


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


           
                Stage0Ligth.SetActive(false);
                Stage1Light.SetActive(true);
                Debug.Log("hello");

     ;
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
