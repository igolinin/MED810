using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCatalog : MonoBehaviour
{

    public GameObject[] types;
    public int ChoosenType;

    void Start()
    {
        ChoosenType = Random.Range(0, 10);
        ChangeChoice();
    }
    void ChangeChoice()
    {
        for (int i=0; i<types.Length; i++)
        {
            if (ChoosenType == i)
            {
                types[i].SetActive(true);
            }
            else
            {
                types[i].SetActive(false);
            }
        }
    }

    public void add()
    {
        ChoosenType += 1;
        if (ChoosenType == 5)
        {
            ChoosenType = 0;
        }
        ChangeChoice();
    }

    public void reduce()
    {
        ChoosenType -= 1;
        if (ChoosenType < 0)
        {
            ChoosenType = 4;
        }
        ChangeChoice();
    }



}
