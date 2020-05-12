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
    public GameObject Instruction;
    public GameObject Instruction2;
    public PlanetInfo pI;
    public int currentRow;
    

    [SerializeField]
    public GameObject[] Stars;

    public float camPosX;
    public float camPosY;
    public calcSize size;
    public float halfOfFOV;
    private bool starSelected = false;
    private bool starZoomedIn;
    private bool zoomDone;
    private bool FirstTime = false;

    public Image CrossHair;
    public Image planetIcon;
    public TextMeshProUGUI counter;
    public GameObject[] instr;

    //public static int[] SelectedPlanet = new int[10];
    public static List<int> SelectedPlanet = new List<int>();
    private int[] planetsFound = new int[10];


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
        planetIcon.DOFade(0, 0);


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


        if (Input.GetKeyDown("space") && zoomDone)
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

            }
            if ((camPosY < -((size.sizeY / 2) - halfOfFOV) && rb.velocity.y < 0) || (camPosY > (size.sizeY / 2) - halfOfFOV && rb.velocity.y > 0))
            {
                transform.position = new Vector3(checkPos.x, checkPos.y * -1, -checkPos.z);
            }

        }


        for (int i = 0; i < Stars.Length; i++)
        {

            //if the centerpoint of the camera is equal to one of the stars position inside of the checkStarPos array
            if (Mathf.Abs(camPosX - checkStarPos[i].x) <= 2 && Mathf.Abs(camPosY - checkStarPos[i].y) <= 2 && !starZoomedIn)
            {
                //The camera moves to center the planet in the screen 
                transform.position = Vector2.MoveTowards(transform.position, checkStarPos[i], 2.5f * Time.deltaTime);
                if (FirstTime == false)
                {
                    Instruction.SetActive(false);
                    Instruction2.SetActive(true);
                    FirstTime = true;
                }


                //If the planet is centerd 
                if (Mathf.Abs(camPosX - checkStarPos[i].x) <= 0 && Mathf.Abs(camPosY - checkStarPos[i].y) <= 0 && !starZoomedIn && Input.GetKeyDown("space"))
                {
                    //Add the planet name makes it in ot a int to be used in the S3to4 script 
                    currentRow = int.Parse(Stars[i].name);
                    if (pI.info[int.Parse(Stars[i].name), 1].Equals("0"))
                    {
                        SelectedPlanet.Add(int.Parse(Stars[i].name));
                        pI.info[int.Parse(Stars[i].name), 1] = "1";
                    }
                    
                    Debug.Log("this is the selected planet" + currentRow);
                    starName.SetText(pI.info[currentRow, 2]);
                    distText.SetText(pI.info[currentRow, 3]);
                    posText.SetText(pI.info[currentRow, 4]);
                    typeText.SetText(pI.info[currentRow, 5]);

                    selected();
                    counter.text = "Exoplanets found:" + SelectedPlanet.Count.ToString() + "/10";
                    
                    instr[0].GetComponent<TextMeshProUGUI>().enabled = false;
                    instr[1].GetComponent<TextMeshProUGUI>().enabled = false;
                    planetIcon.DOFade(1, 1f);

                    //To make this if statement go off only one time. 
                    starZoomedIn = true;
                    Instruction2.SetActive(false);
                    planetsFound[i] = int.Parse(Stars[i].name);
                    Debug.Log(planetsFound[i] + " // " + planetsFound.Length);

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
        if (!starZoomedIn)
        {
            rb.velocity = -direction * speed;


        }
    }


    void selected()
    {
        Camera.main.DOFieldOfView(12, 2);
        CrossHair.DOFade(0, 1);
        starName.DOFade(1, 1f);

        Invoke("animatePointer",2);
        Invoke("zoomInDone", 3);

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
        Invoke("zoomOutDone", 1.5f);
        
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


    void zoomOutDone() 
    {
        starZoomedIn = false;
        zoomDone = false;
    }

    void zoomInDone()
    {
        zoomDone = true;

    }
}
