using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    public string[,] info;
    void Start()
    {
        /*
         * [0] = the number of the planet (or gameobject)
         * [1] = if selected then 1 if not selected then 0 (always start with 0)
         * [2] = string name of the planet
         * [3] = distance
         * [4] = position
         * [5] = type
         */
        info = new string[10, 6]
        {
            {"0","0","name0","distance0","position0","type0"},
            {"1","0","name1","distance1","position1","type1"},
            {"2","0","name2","distance2","position2","type2"},
            {"3","0","name3","distance3","position3","type3"},
            {"4","0","name4","distance4","position4","type4"},
            {"5","0","name5","distance5","position5","type5"},
            {"6","0","name6","distance6","position6","type6"},
            {"7","0","name7","distance7","position7","type7"},
            {"8","0","name8","distance8","position8","type8"},
            {"9","0","name9","distance9","position9","type9"}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
