using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{


    public GameObject Target;
    public GameObject Earth;

    float speed = 1;

    float minFov = 7f;
    float maxFov = 150f;
    float sensitivity = 17f;



    // Update is called once per frame
    void Update()
    {

        //Touch implementation 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {

                case TouchPhase.Began:


                    break;

                case TouchPhase.Moved:
                    Target.transform.position = new Vector3();
                    Target.transform.Rotate(new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * -speed);
                    Target.transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * speed, Space.World);
                    Target.transform.Translate(new Vector3(0, 0, -2));

                    break;

                case TouchPhase.Ended:

                    break;


            }
        }
        else
        {
            //Rotates the sun slowly 
            Earth.transform.Rotate(new Vector3(0, 0.1f, 0));
        }




        /*

        //Rotation
        if (Input.GetMouseButton(0))
        {


            Target.transform.position = new Vector3();
            Target.transform.Rotate(new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * -speed);
            Target.transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * speed, Space.World);
            Target.transform.Translate(new Vector3(0, 0, -3));


        }
        else
        {
            //Rotates the sun slowly 
            Earth.transform.Rotate(new Vector3(0, 0.001f, 0));
        }

        //ZOOM
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        if(fov < 25)
        {

            speed = 2;
        }
        else
        {
            speed = 5;
        } 

    }
            */

    }
}
