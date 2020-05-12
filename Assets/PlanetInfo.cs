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
         * [4] = position - Star
         * [5] = type - Constellation
         */
        info = new string[10, 6]
        {
            {"0","0","Proxima b","Distance: 4.24 light years","Star:  Red dwarf Proxima Centauri","Constellation: Centaurus"},
            {"1","0","WASP-12b","Distance: 870.8 light years","Star: Yellow dwarf WASP-12","Constellation: Auriga"},
            {"2","0","OGLE-2005-BLG-390Lb","Distance: 21,530 light years","Star: Red dwarf OGLE-2005-BLG-390L","Constellation: Sagittarius"},
            {"3","0","Gliese 667 Cc","Distance: 22.18 light years","Star‎: ‎Red dwarf Gliese 667C","Constellation: Scorpius"},
            {"4","0","51 Pegasi b","Distance: 50 light years","Star:  Sun-like star 51 Pegasi","Constellation: Pegasus"},
            {"5","0","CoRoT-7b","Distance: 489 light years","Star:  Yellow dwarf CoRoT-7","Constellation: Monoceros"},
            {"6","0","Kepler 16b","Distance: 200 light years","Star: Binary Star, Kepler-16A and Kepler-16B","Constellation: Cygnus"},
            {"7","0","Gliese 436 b","Distance: 33.01 light years","Star: Red dwarf Gliese 436","Constellation: Leo"},
            {"8","0","OGLE-2016-BLG-1195Lb","Distance: 13,000 light-years","Star: Ultra-cool dwarf OGLE-2016-BLG-1195L","Constellation: Sagittarius"},
            {"9","0","Gliese 1214b","Distance: 40 light years","Star:  Red dwarf Gliese 1214","Constellation: Ophiuchus"}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
