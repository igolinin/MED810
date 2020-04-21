using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameControl : MonoBehaviour
{

    [SerializeField]
    public GameObject winText;
    public TextMeshPro winTextFade;

    public TextMeshPro TextHeader;
    public TextMeshPro TextBody;

    public static bool info1Close;
    public static bool info2Close;
    public static bool info3Close;




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //If the object is placed on the right spot
        if (Obj_1_move.locked && info1Close == false)
        {
            TextHeader.text = "Primary mirror";
            TextBody.text = "We can capture the light. Now lets direct the light to the eye. Place secondary mirror in the middle of the tube.";
            info1Close = true;
            Debug.Log("First step");

        } else if (Obj_2_move.locked && info2Close == false && info1Close == true)
        {
            TextHeader.text = "Secondary Mirror";
            TextBody.text = "To enlarge the image we need to magnify it with the eyepiece lens.";
            info2Close = true;
            Debug.Log("Second Step");
        }
        else if (Obj_3_move.locked && info3Close == false && info2Close ==  true)
        {
            TextHeader.text = "Eyepiece";
            TextBody.text = "To enlarge the image we need to magnify it with the eyepiece lens.";
            info3Close = true;
            Debug.Log("Third Step");
        }
        else if(Obj_1_move.locked && Obj_2_move.locked && Obj_3_move.locked)
        {
            winText.SetActive(true);

            Invoke("fadeText", 1);

        }




        //Open the info sign
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);


            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Object1") && Obj_1_move.locked)
                {
                    info1Close = false;
                    Debug.Log("circle");
                }
                else if (hit.collider.CompareTag("Object2") && Obj_2_move.locked)
                {
                    info2Close = false;
                    Debug.Log("Box");

                } else if (hit.collider.CompareTag("Object3") && Obj_3_move.locked)
                {
                    info3Close = false;
                    Debug.Log("Sensor");
                }

            }
           
        }
         

    }

    void fadeText()
    {
        winTextFade.DOFade(0,2);


    }
}
