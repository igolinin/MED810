using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class ChoosenPlanet : MonoBehaviour
{
    public string Name;
    public bool choosen;
    [TextArea(3, 3)]
    public string description;
    public int SerialNum;
    public bool found;
    public string Size;
    public string Water, Light, Life, Atmosphere, Gravity;
    public string Surface;
    public int Temprature;
    public int type;
    public TextMeshProUGUI N,D, W, Lg, Lf, A, T, G, Sf;
    public TextMeshProUGUI Nx, Sx, Wx, Lgx, Lfx, Ax, Tx, Gx, Sfx;
    public GameObject cata;
    public ScreenControl Control;
    public GameObject NotFound;
    public bool once=true;
    public S3toS4 List;

    // Start is called before the first frame update
    void Start()
    {
        CheckFound();

        if (found==false)
        {
            NotFound.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (choosen&&once)
        {
            Control.GetComponent<ScreenControl>().PlanetN = SerialNum;
            once = false;
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

    public void CheckFound()
    {
        if (S3toS4.ListFound[(SerialNum-1)] == true)
        {
            found = true;
        }

        else
        {
            found = false;
        }
    }
}
