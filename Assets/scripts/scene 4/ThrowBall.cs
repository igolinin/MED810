using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowBall : MonoBehaviour
{
    public GameObject[] Surfaces;
    public GameObject ball;
    int Num;
    int i;
    public ScreenControl sc;
    public float[] Grav;
    public GameObject ball1;
    public Slider slider;
    Vector3 ballPosition;
    Vector3 ball1Position;

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = ball.transform.position;
        ball1Position = ball1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Num != sc.PlanetN&& sc.PlanetN!=0)
        {
            Num = sc.PlanetN;
            ChangeSurface();
        }
    }

    void ChangeSurface()
    {
        if (Num == 2 || Num == 3 || Num == 7 || Num == 8)
        {
            //Gas planets
            i = 0;
        }
        else if (Num == 1 || Num == 4)
        {
            //Ice planets
            i = 1;
        }
        else if (Num == 5)
        {
            //Lava
            i = 2;
        }
        else if (Num == 9)
        {
            //water
            i = 3;
        }
        else
        { //earth
            i = 4;
        }
        Surfaces[i].SetActive(true);
        ball.GetComponent<Rigidbody>().mass = Grav[i];
    }

    public void Restart()
    {
        slider.value = 0.0f;
        Rigidbody r = ball.GetComponent<Rigidbody>();
        Rigidbody r2 = ball1.GetComponent<Rigidbody>();
        r.useGravity = false;
        r2.useGravity = false;
        r.velocity = new Vector3(0,0);
        r2.velocity = new Vector3(0, 0);
        ball.transform.position = ballPosition;
        ball1.transform.position = ball1Position;

    }
}
