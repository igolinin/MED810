using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject timer;
    public float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("timer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer.GetComponent<Text>().text = (counter += Time.deltaTime).ToString();
        Debug.Log(counter += Time.deltaTime);
    }
}
