using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetType : MonoBehaviour
{
    public string TypeName;
    public string Size;
    public string Water, Light, Life, Atmosphere, Temprature, Gravity;
    public string Surface;
    public TextMeshProUGUI N, Sz, W, Lg, Lf, A, T, G, Sf;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        N.text = TypeName;
        Sz.text = Size;
        W.text = Water + "%";
        Lg.text = Light + "%";
        Lf.text = Life;
        A.text = Atmosphere + "%";
        T.text = Temprature + "c";
        G.text = Gravity;
        Sf.text = Surface;
    }
}
