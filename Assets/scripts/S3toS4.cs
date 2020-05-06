using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3toS4 : MonoBehaviour
{

   public static bool[] ListFound = new bool[10];
   public static int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = CameraController2.SelectedPlanet.Count;
        Debug.Log(counter + " What I FOUND!!!");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ListFound.Length; i++)
        {
            for (int j = 0; j < counter; j++)
            {
                if (CameraController2.SelectedPlanet[j] == i)
                {
                    ListFound[i] = true;
                }

            }

        }
    }
}
