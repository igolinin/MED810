using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrbitControl : MonoBehaviour
{
    public Slider launch;
    public Animator satellite;
    public Animator satellite2;
    private bool flag = false;
    private bool moving = false;
    private bool success = false;
    private float velocity;
    private float duration;
    private float animStartTime;
    private int loops = 0;

    public GameObject start;
    public GameObject stop;
    public GameObject next_button;
    public Button retry_button;

    public TextMeshProUGUI Orbit_days_exoplanet;
    public TextMeshProUGUI Orbit_days_earth;
    public TextMeshProUGUI comparison;

    private void Start()
    {
        velocity = satellite.GetFloat("relative_speed");
        duration = satellite.GetCurrentAnimatorStateInfo(0).length / velocity;
        satellite.transform.position = new Vector3(-3.52f, -2.65f, 0f);
        satellite2.transform.position = new Vector3(-3.36f, -2.65f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (launch.value == 1.0 && flag == false)
        {
            satellite.SetTrigger("Launch");
            satellite2.SetTrigger("Launch");
            animStartTime = Time.time;
            moving = true;
            start.SetActive(false);
            stop.SetActive(true);
            flag = true;
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


        if (velocity > 1)
        {
            comparison.text = velocity.ToString() + "X Faster";
        }
        else if (velocity < 1)
        {
            velocity = 1 / velocity;
            comparison.text = velocity.ToString() + "X Slower";
        }
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
}
