using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameCrl_2 : MonoBehaviour
{
    [SerializeField]
    public GameObject winText;
    public TextMeshPro winTextFade;

    public static bool info1Close;
    public static bool info2Close;
    public static bool info3Close;

    public GameObject intro;
    public GameObject primaryInfo;
    public GameObject secondaryInfo;
    public GameObject lensInfo;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //If the object is placed on the right spot
        if (Obj1_MouseMove.locked && info1Close == false)
        {
            primaryInfo.SetActive(true);


            info1Close = true;
            Debug.Log("First step");

        }
        else if (Obj2_MouseMove.locked && info2Close == false && info1Close == true)
        {
            secondaryInfo.SetActive(true);
            info2Close = true;
            Debug.Log("Second Step");
        }
        else if (Obj3_MouseMove.locked && info3Close == false && info2Close == true)
        {
            lensInfo.SetActive(true);

            info3Close = true;
            Debug.Log("Third Step");
        }
        else if (Obj1_MouseMove.locked && Obj2_MouseMove.locked && Obj3_MouseMove.locked)
        {
            winText.SetActive(true);

            Invoke("fadeText", 1);

        }




        //Open the info sign
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);


            if (hit.collider != null && Obj_1_move.locked && Obj_2_move.locked && Obj_3_move.locked)
            {
                if (hit.collider.CompareTag("Object1") && Obj_1_move.locked)
                {

                    primaryInfo.SetActive(true);
                    Debug.Log("circle");
                }
                else if (hit.collider.CompareTag("Object2") && Obj_2_move.locked)
                {
                    secondaryInfo.SetActive(true);
                    Debug.Log("Box");

                }
                else if (hit.collider.CompareTag("Object3") && Obj_3_move.locked)
                {
                    lensInfo.SetActive(true);
                    info3Close = false;
                    Debug.Log("Sensor");
                }
                else
                {
                    primaryInfo.SetActive(false);
                    secondaryInfo.SetActive(false);
                    primaryInfo.SetActive(false);
                }


            }



        }


    }

    void fadeText()
    {
        winTextFade.DOFade(0, 2);


    }
}
