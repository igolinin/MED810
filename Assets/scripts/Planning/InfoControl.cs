using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InfoControl : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Header;
    public TextMeshProUGUI Location;
    public TextMeshProUGUI TelescopeInfo;
    public TextMeshProUGUI PlanetsInfo;



    [SerializeField]
    public Sprite[] TeleImage;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }


    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.collider.gameObject.name == "Denmark")
            {
                Image.sprite = TeleImage[0];
                Header.text = "Brorfelde Observatorium";
                Location.text = "Brorfelde Observatorium, Denmark";
                TelescopeInfo.text = "The 77-centimetre Schmidt telescope from 1966 at Brorfelde Observatory was equipped with photographic film.";
                Debug.Log("Denmark Change Text");
                    
             }
            else if (hit.collider.gameObject.name == "Chile Parnal")
            {

                Image.sprite = TeleImage[1];
                Header.text = "Paranal Observatory";
                Location.text = "Paranal Observatory, Chile";
                TelescopeInfo.text = "Composed of four separate 8.2 m (320 in) telescopes. The four main telescopes can be used simultaneously for extra light gathering capacity";
            }
            else if (hit.collider.gameObject.name == "Chile La Silla")
            {
                Image.sprite = TeleImage[2];
                Header.text = "La Silla Observatory";
                Location.text = "La Silla Observatory, Chile";
                TelescopeInfo.text = "The observatory operates three major optical and near infrared telescopes.";


            }
            else if (hit.collider.gameObject.name == "Chile Atacama")
            {
                Image.sprite = TeleImage[3];
                Location.text = "San Pedro de Atacama, Chile";
                Header.text = "University Of Tokyo Atacama Observatory";
                TelescopeInfo.text = "The telescope's primary mirror will have a diameter of 6.5 m, the secondary mirror have adaptive optics to compensate for atmospheric turbulence.";

            }
            else if (hit.collider.gameObject.name == "South Africa")
            {

                Image.sprite = TeleImage[4];
                Header.text = "South African Astronomical Observatory";
                Location.text = "Cape Town, South Africa";
                TelescopeInfo.text = "The primary telescopes are located in Sutherland, which is 370 kilometres (230 mi) from Observatory, Cape Town, where the headquarters is located.";


            }
            else if (hit.collider.gameObject.name == "Spain Astrofisico")
            {
                Image.sprite = TeleImage[5];
                Header.text = "Roque De Los Muchachos Observatory";
                Location.text = "Santa Cruz de Tenerife, Spain";
                TelescopeInfo.text = "The Spanish island is host to the premiere collection of telescopes and observatories from around the World";

            }
            else if (hit.collider.gameObject.name == "Hawaii Mauna Kea")
            {
                Image.sprite = TeleImage[6];
                Header.text = "Mauna Kea Observatories";
                Location.text = "Hawaii, USA";
                TelescopeInfo.text = "twelve facilities housing thirteen telescope at or around the summit of Mauna Kea. ";
                

            }
            else if (hit.collider.gameObject.name == "South Pole Telescope")
            {
                Image.sprite = TeleImage[7];
                Header.text = "South Pole Telescope";
                Location.text = "South Pole, Antarctica";
                TelescopeInfo.text = "The South Pole Telescope is a 10-meter diameter telescope, the surface of the telescope mirror is smooth down to roughly 25 micrometers";

            }
            else if (hit.collider.gameObject.name == "Yerkes Observatory")
            {
                Image.sprite = TeleImage[8];
                Header.text = "Yerkes Observatory";
                Location.text = "Williams Bay, USA";
                TelescopeInfo.text = "The observatory houses a 102cm diameter doublet lens refracting telescope, the largest ever successfully used for astronomy";


            }
            else if (hit.collider.gameObject.name == "Kitt Peak Observatory")
            {
                Image.sprite = TeleImage[9];
                Header.text = "Kitt Peak National Observatory";
                Location.text = "Tucson, USA";
                TelescopeInfo.text = "The largest optical instruments at KPNO are the Mayall 4 meter telescope and the WIYN 3.5 meter telescope.";
                PlanetsInfo.text = "The 90 cm Spacewatch telescope was used to discover the Kuiper belt body, 20000 Varuna in the year 2000.";

            }
            else if (hit.collider.gameObject.name == "Arecibo Observatory")
            {
                Image.sprite = TeleImage[10];
                Location.text = "Arecibo, Puerto Rico"; 
                Header.text = "Arecibo Observatory";
                TelescopeInfo.text = "The main collecting dish is 305 m (1,000 ft) in diameter, constructed inside the depression left by a karst sinkhole.";

            }
            else if (hit.collider.gameObject.name == "BTA-6 Russia")
            {

                Image.sprite = TeleImage[11];
                Location.text = "Karachay-Cherkessia, Russia";
                Header.text = "BTA-6 Observatory";
                TelescopeInfo.text = "The BTA primary is a 605 cm f/4 mirror, BTA-6 is enclosed in a massive dome, 53 m tall at the peak";
            }
            else if (hit.collider.gameObject.name == "Sydney Observatory")
            {
                Image.sprite = TeleImage[12];
                Location.text = "Sydney, Australia"; 
                Header.text = "Sydney Observatory";
                TelescopeInfo.text = "Is a working museum with a modern 40-centimetre (16 in) Schmidt-Cassegrain telescope and an historic 29-centimetre telescope";
            }

        }
    }
}
