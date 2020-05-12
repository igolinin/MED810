using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void finish()
    {
        SceneManager.LoadScene("AgainScene", LoadSceneMode.Single);
    }

    public void Back()
    {
        SceneManager.LoadScene("Station3", LoadSceneMode.Single);
    }
}
