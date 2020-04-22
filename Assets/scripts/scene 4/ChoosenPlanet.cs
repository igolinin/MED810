using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoosenPlanet : MonoBehaviour
{
    public string Name;
    public bool choosen;
    [TextArea(3, 3)]
    public string description;
    public string Size;
    public string Water, Light, Life, Atmosphere, Gravity;
    public string Surface;
    public int Temprature;
    public int type;
    public TextMeshProUGUI N,D, W, Lg, Lf, A, T, G, Sf;
    public TextMeshProUGUI Nx, Sx, Wx, Lgx, Lfx, Ax, Tx, Gx, Sfx;
    public GameObject cata;
    public ScreenControl Control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (choosen)
        {
            
            N.text = Name;
            D.text = description;
            W.text = Water+ " Water";
            Lg.text = Light+ " Light";
            Lf.text = Life;
            A.text = Atmosphere +" Atmosph";
            T.text = Temprature.ToString()+ "c";
            G.text = Gravity;
            Sf.text = Surface;
            Nx.text = Name;
            Sx.text = Size;
            Wx.text = Water;
            Lgx.text = Light;
            Lfx.text = Life;
            Ax.text = Atmosphere;
            Tx.text = Temprature.ToString() + "c";
            Gx.text = Gravity;
            Sfx.text = Surface;
        }

    }

    public void Answer()
    {
        if (type == cata.GetComponent<PlantCatalog>().ChoosenType)
        {
            Control.NextButton();
        }
        else
        {
            Control.wrong();
        }
    }
}
