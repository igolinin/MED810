using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class OrbitControl : MonoBehaviour
{
    public Slider launch;
    public Animator satellite;
    public Animator satellite2;
    public GameObject satellite_obj;
    public GameObject satellite2_obj;
    public GameObject Control;
    private bool flag = false;
    private bool moving = false;
    private bool success = false;
    private float velocity;
    private float duration;
    private float animStartTime;
    private bool stop_button = false;
    private int loops = 0;
    public float[] PlanetRadius;
    public float[] PlanetSize;
    public string[] Orbit_text;

    public GameObject start;
    public GameObject stop;
    public GameObject next_button;
    public Button retry_button;
    public Image pointer_exoplanet;
    public Image pointer_earth;

    public TextMeshProUGUI Orbit_days_exoplanet;
    public TextMeshProUGUI Orbit_days_earth;
    public TextMeshProUGUI comparison;
    public TextMeshProUGUI info_text;

    private void Start()
    {
        //satellite.transform.position = new Vector3(-3.52f, -2.65f, 0f);
        //satellite2.transform.position = new Vector3(-3.36f, -2.65f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (launch.value == 1.0 && flag == false)
        {
            int Num = Control.GetComponent<ScreenControl>().PlanetN;

            satellite_obj.SetActive(true);
            satellite.SetTrigger("Launch");
            velocity = 1.0f / PlanetRadius[Num-1];
            duration = satellite.GetCurrentAnimatorStateInfo(0).length / velocity;
            satellite.SetFloat("relative_speed", velocity);
            satellite.transform.localScale = new Vector3(2* PlanetRadius[Num - 1], 2*PlanetRadius[Num - 1], 2*PlanetRadius[Num - 1]);
            satellite_obj.transform.localScale = new Vector3(0.28298f, 0.28928f, 0.28928f);

            satellite2_obj.SetActive(true);
            satellite2.SetTrigger("Launch");
            animStartTime = Time.time;
            moving = true;
            start.SetActive(false);
            stop_button = true;
            flag = true;

            if (PlanetSize[Num - 1] > 1.0)
            {
                comparison.text = PlanetSize[Num - 1].ToString() + "X Bigger";
            }
            else
            {
                comparison.text = "The same size as the Earth";
            }
            info_text.text = Orbit_text[Num - 1];
        }

        if (Time.time > animStartTime + 1 && stop_button == true)
        {
            stop.SetActive(true);
            stop_button = false;
        }

        if (Time.time > animStartTime + duration && moving == true)
        {
            animStartTime = Time.time;
            loops++;
        }

        if (loops > 3 && moving == true)
        {
            StopSatellites_Unsuccessful();
            moving = false;
        }

    }

    public void StopSatellites_Successful()
    {
        satellite.speed = 0;
        satellite2.speed = 0;
        stop.SetActive(false);
        next_button.SetActive(true);


        int days = (int)Mathf.Floor(365f / velocity);
        Orbit_days_exoplanet.text = days.ToString() + " days";
        Orbit_days_earth.text = "365 days";

        pointer_exoplanet.DOFillAmount(1, 1);
        Orbit_days_exoplanet.DOFade(1, 1);

        StartCoroutine(waiter());

        pointer_earth.DOFillAmount(1, 1);
        Orbit_days_earth.DOFade(1, 1);

        success = true;
    }

    public void StopSatellites_Unsuccessful()
    {
        if (!success)
        {
            //satellite.speed = 0;
            //satellite2.speed = 0;
            GameObject go = GameObject.Find("Main Camera");
            ScreenControl sc = (ScreenControl)go.GetComponent(typeof(ScreenControl));
            sc.wrong();

            start.SetActive(true);
            launch.value = 0.0f;
            stop.SetActive(false);

            satellite.SetTrigger("Restart");
            satellite2.SetTrigger("Restart");
            satellite.ResetTrigger("Launch");
            satellite2.ResetTrigger("Launch");
            flag = false;
            loops = 0;
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(4);
    }
}
