using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickAction : MonoBehaviour
{

    public GameObject UI;
    public int ZoomInVal =20;
    private SpriteRenderer activeLocationSprite;
    Color32 orginalColor = new Color32(255, 90, 104, 255);

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
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "Denmark")
            {

                Debug.Log("You hit the Denmark Telescope");
                Camera.main.transform.DOMove(new Vector3(-0.5110375f, 2.465688f, 1.630713f), 2);
                Camera.main.transform.DORotate(new Vector3(55.275f, 162.6f, 0), 2f);
                hit.collider.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 1);
                activeLocationSprite = hit.collider.GetComponentInChildren<SpriteRenderer>();
                zoomIn();
                UI.SetActive(true);
            }
            else if (hit.collider.gameObject.name == "Chile Parnal")
            {
                
                Camera.main.transform.DOMove(new Vector3(2.528032f, -1.166163f, 1.117641f), 2);
                Camera.main.transform.DORotate(new Vector3(-22.875f, -113.85f, 0), 2f);
                zoomIn();
                UI.SetActive(true);
                Debug.Log("You hit the London Telescope");

            }
            else if (hit.collider.gameObject.name == "Chile La Silla")
            {
                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(2.208235f, -1.749557f, 1.030898f), 2);
                Camera.main.transform.DORotate(new Vector3(-35.675f, -115.025f, 0), 2f);
                zoomIn();
                Debug.Log("You hit the Chile La Silla");

            }
            else if (hit.collider.gameObject.name == "Chile Atacama")
            {
                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(2.493308f, -1.157715f, 1.201296f), 2);
                Camera.main.transform.DORotate(new Vector3(-22.7f, -115.725f, 0), 2f);
                zoomIn();
                Debug.Log("You hit the Chile Atacama");

            }
            else if (hit.collider.gameObject.name == "South Africa")
            {
                UI.SetActive(true);
                Debug.Log("You hit the Rome Telescope");
                Camera.main.transform.DOMove(new Vector3(-1.022735f, -1.643786f, 2.291721f), 2);
                Camera.main.transform.DORotate(new Vector3(-33.225f, 155.95f, 0),2f);
                zoomIn();

            }
            else if (hit.collider.gameObject.name == "Spain Astrofisico")
            {

                Camera.main.transform.DOMove(new Vector3(0.538725f, 1.445267f, 2.573127f), 2);
                Camera.main.transform.DORotate(new Vector3(28.8f, -168.175f, 0), 2f);
                zoomIn();
                UI.SetActive(true);
                Debug.Log("You hit the LAq Telescope");

            }
            else if (hit.collider.gameObject.name == "Hawaii Mauna Kea")
            {
                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(1.455225f, 1.042033f, -2.407589f), 2);
                Camera.main.transform.DORotate(new Vector3(20.325f, -31.15f, 0f), 2f);
                zoomIn();
                Debug.Log("You hit the Hawaii Manua Kea");

            }
            else if (hit.collider.gameObject.name == "South Pole Telescope")
            {
                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(0.130209f, -2.972597f, 0.3830299f), 2);
                Camera.main.transform.DORotate(new Vector3(-82.25001f, -161.225f, 0f), 2f);
                zoomIn();
                Debug.Log("You hit the South Pole Telescope");

            }
            else if (hit.collider.gameObject.name == "Yerkes Observatory")
            {
                

                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(2.155519f, 2.063167f, 0.3115776f), 2);
                Camera.main.transform.DORotate(new Vector3(43.45f, -98.22501f, 0f), 2f);
                zoomIn();
                Debug.Log("You hit the Yerkes Observatory");

            }
            else if (hit.collider.gameObject.name == "Kitt Peak Observatory")
            {
                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(2.447473f, 1.610798f, -0.6443663f), 2);
                Camera.main.transform.DORotate(new Vector3(32.475f, -75.25f, 0f), 2f);
                zoomIn();
                Debug.Log("Kitt Peak Observatory");

            }
            else if (hit.collider.gameObject.name == "Arecibo Observatory")
            {
                UI.SetActive(true);
                Camera.main.transform.DOMove(new Vector3(2.453713f, 0.9630774f, 1.432402f), 2);
                Camera.main.transform.DORotate(new Vector3(18.725f, -120.275f, 0f), 2f);
                zoomIn();
                Debug.Log("You hit the Arecibo Observatory");
            }
            else if (hit.collider.gameObject.name == "BTA-6 Russia")
            {
                UI.SetActive(true);

                Camera.main.transform.DOMove(new Vector3(-1.662475f, 2.086801f, 1.371656f), 2);
                Camera.main.transform.DORotate(new Vector3(44.075f, 129.525f, 0f), 2f);
                zoomIn();
                Debug.Log("You hit the Russia Telescope");

            }
            else if (hit.collider.gameObject.name == "Sydney Observatory")
            {
                UI.SetActive(true);

                Camera.main.transform.DOMove(new Vector3(-0.9204969f, -1.583087f, -2.376241f), 2);
                Camera.main.transform.DORotate(new Vector3(-31.85f, 21.175f, 0f), 2f);
                Debug.Log("You hit the Sydney Telescope");
                zoomIn();
            }
            else if(hit.collider.gameObject.name == "Earth" && UI.activeSelf == true)
            {

                Invoke("closeUI", 0.5f);

            }
        }
    }

    public void closeUI()
    {
        UI.SetActive(false);
        Camera.main.DOFieldOfView(30, 2);
        activeLocationSprite.DOColor(orginalColor, 1);
        Debug.Log(activeLocationSprite);
        Debug.Log("Zoom out");

    }

    public void zoomIn()
    {
        Camera.main.DOFieldOfView(ZoomInVal, 2);


    }
}
