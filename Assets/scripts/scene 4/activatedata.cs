using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activatedata : MonoBehaviour
{

    public GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        data.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        data.SetActive(true);
    }
}
