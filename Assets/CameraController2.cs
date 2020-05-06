using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Rendering;

public class CameraController2 : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody2D rb;
    public TextMeshProUGUI starName;
    public TextMeshProUGUI distText;
    public TextMeshProUGUI posText;
    public TextMeshProUGUI typeText;
    public Image pointer;
    public Vector2 movement;
    public Vector3 checkPos;
    public Vector2[] checkStarPos;
    public GameObject nextBtn;
    public GameObject btnTxt;

    [SerializeField]
    public GameObject[] Stars;

    public float camPosX;
    public float camPosY;
    public calcSize size;
    public float halfOfFOV;
    private bool starSelected = false;
    private bool starZoomedIn;
    public Image CrossHair;
    public TextMeshProUGUI counter;
    public GameObject[] instr;

    //public static int[] SelectedPlanet = new int[10];
    public static List<int> SelectedPlanet = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        SelectedPlanet.Clear();
        rb = GetComponent<Rigidbody2D>();
        halfOfFOV = Camera.main.fieldOfView / 2;
        starSelected = false;
        counter = GameObject.FindGameObjectWithTag("counter").GetComponent<TextMeshProUGUI>();
        instr = GameObject.FindGameObjectsWithTag("instructions");
        nextBtn = GameObject.FindGameObjectWithTag("NextBtn");
        btnTxt = GameObject.FindGameObjectWithTag("btnTxt");


        //Create an array for the positions of the stars and populate it with the for look 
        checkStarPos = new Vector2[Stars.Length];
        for (int i = 0; i < checkStarPos.Length; i++)
        {
            checkStarPos[i] = new Vector2(Stars[i].transform.position.x, Stars[i].transform.position.y);

        }


    }

    // Update is called once per frame
    void Update()
    {
        controlWithMouse();
        if(SelectedPlanet.Count > 0)
        {
            btnTxt.GetComponent<TextMeshProUGUI>().enabled = true;
            nextBtn.GetComponent<Image>().enabled = true;
        }


        if (Input.GetKeyDown("space") && Camera.main.fieldOfView == 12)
        {
            deselectStar();
            Debug.Log("SpaceDown Out");
        }


    }
    void controlWithMouse()
    {

        camPosX = rb.transform.position.x;
        camPosY = rb.transform.position.y;
        checkPos = new Vector3(camPosX, camPosY, transform.position.z);

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        if (Input.GetMouseButton(0))
        {
            //Camera Movements  
            movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if ((camPosX < -((size.sizeX / 2) - halfOfFOV) && rb.velocity.x < 0) || (camPosX > (size.sizeX / 2) - halfOfFOV && rb.velocity.x > 0))
            {
                transform.position = new Vector3(checkPos.x * -1, checkPos.y, checkPos.z);
                Debug.Log("hello");

            }
            if ((camPosY < -((size.sizeY / 2) - halfOfFOV) && rb.velocity.y < 0) || (camPosY > (size.sizeY / 2) - halfOfFOV && rb.velocity.y > 0))
            {
                transform.position = new Vector3(checkPos.x, checkPos.y * -1, -checkPos.z);
                Debug.Log("HellNo");
            }

        }


        for (int i = 0; i < Stars.Length; i++)
        {

            //if the centerpoint of the camera is equal to one of the stars position inside of the checkStarPos array
            if (Mathf.Abs(camPosX - checkStarPos[i].x) <= 2 && Mathf.Abs(camPosY - checkStarPos[i].y) <= 2 && !starZoomedIn)
            {
                //The camera moves to center the planet in the screen 
                transform.position = Vector2.MoveTowards(transform.position, checkStarPos[i], 2.5f * Time.deltaTime);


                //If the planet is centerd 
                if (Mathf.Abs(camPosX - checkStarPos[i].x) <= 0 && Mathf.Abs(camPosY - checkStarPos[i].y) <= 0 && !starZoomedIn && Input.GetKeyDown("space"))
                {
                    //Add the planet name makes it in ot a int to be used in the S3to4 script 
                    SelectedPlanet.Add(int.Parse(Stars[i].name));
                    Debug.Log(Stars[i].name + "added to the list");
                    
                    selected();
                    counter.text = "Exoplanets found:" + SelectedPlanet.Count.ToString();
                    instr[0].GetComponent<TextMeshProUGUI>().enabled = false;
                    instr[1].GetComponent<TextMeshProUGUI>().enabled = false;

                    //To make this if statement go off only one time. 
                    starZoomedIn = true;

                    if (Input.GetMouseButtonDown(1))
                    {
                        starSelected = !starSelected;
                        //toggle(starSelected);

                    }
                }

            }



        }
    }


        void FixedUpdate()
    {
        cameraControl(movement);
    }

    void cameraControl(Vector2 direction)
    {
        rb.velocity = -direction * speed;
    }


    void selected()
    {
        Camera.main.DOFieldOfView(12, 2);
        CrossHair.DOFade(0, 1);
        starName.DOFade(1, 1f);

        starSelected = true;
        starZoomedIn = false;
        Invoke("animatePointer",2);
    }
    void deselectStar()
    {
        Camera.main.DOFieldOfView(60, 2);
        pointer.DOFillAmount(0, 0.2f);
        distText.DOFade(0, 0.5f);
        posText.DOFade(0, 0.5f);
        typeText.DOFade(0, 0.5f);
        starName.DOFade(0, 1f);
        CrossHair.DOFade(1, 1);
        Debug.Log(starName);
        starSelected = false;
        starZoomedIn = false;
    }

    void animatePointer()
    {

        pointer.DOFillAmount(1, 1);
        Invoke("fadeInText", 1);
    }
    void fadeInText()
    {
        distText.DOFade(1, 0.5f);
        posText.DOFade(1, 0.5f);
        typeText.DOFade(1, 0.5f);

    }
}
