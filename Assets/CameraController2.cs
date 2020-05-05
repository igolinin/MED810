using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraController2 : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody2D rb;
    public GameObject starName;
    public GameObject distText;
    public GameObject posText;
    public GameObject typeText;
    public GameObject pointer;
    public Vector2 movement;
    public Vector3 checkPos;
    public Vector2[] checkStarPos;

    [SerializeField]
    public GameObject[] Stars;

    public float camPosX;
    public float camPosY;
    public calcSize size;
    public float halfOfFOV;
    private bool starSelected = false;
    private bool starZoomedIn;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        starName = GameObject.FindGameObjectWithTag("starName");
        distText = GameObject.FindGameObjectWithTag("distText");
        posText = GameObject.FindGameObjectWithTag("posText");
        typeText = GameObject.FindGameObjectWithTag("typeText");
        pointer = GameObject.FindGameObjectWithTag("pointer");
        halfOfFOV = Camera.main.fieldOfView / 2;
        starSelected = false;


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

    }
    void controlWithMouse()
    {

        camPosX = rb.transform.position.x;
        camPosY = rb.transform.position.y;
        checkPos = new Vector3(camPosX, camPosY, transform.position.z);

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        if (Input.GetMouseButton(0))
        {
            movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if ((camPosX < -((size.sizeX / 2) - halfOfFOV) && rb.velocity.x < 0) || (camPosX > (size.sizeX / 2) - halfOfFOV && rb.velocity.x > 0))
            {
                transform.position = new Vector3(checkPos.x * -1, checkPos.y, checkPos.z);
            }
            if ((camPosY < -((size.sizeY / 2) - halfOfFOV) && rb.velocity.y < 0) || (camPosY > (size.sizeY / 2) - halfOfFOV && rb.velocity.y > 0))
            {
                transform.position = new Vector3(checkPos.x, checkPos.y * 1, -checkPos.z);
            }

        }
        for (int i = 0; i < Stars.Length; i++)
        {


            if (Mathf.Abs(camPosX - checkStarPos[i].x) <= 6 && Mathf.Abs(camPosY - checkStarPos[i].y) <= 6 )
            {
                
                transform.position = Vector2.MoveTowards(transform.position, checkStarPos[i], 2.5f * Time.deltaTime);


                //If the planet is centerd 
                if(Mathf.Abs(camPosX - checkStarPos[i].x) <= 0 && Mathf.Abs(camPosY - checkStarPos[i].y) <= 0 && !starZoomedIn)
                {
                   Debug.Log(Stars[i].name);
                    
                    starZoomedIn = true;
                    if (Input.GetButtonDown("Jump"))
                    {
                        starSelected = !starSelected;
                        toggle(starSelected);
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    starSelected = !starSelected;
                    //toggle(starSelected);

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

    
    void toggle(bool selected)
    {
        if (selected)
        {
            Camera.main.DOFieldOfView(12, 2);
            starName.GetComponent<Text>().text = "Alpha Centauri";
            distText.GetComponent<Text>().text = "Distance: Far, far away";
            posText.GetComponent<Text>().text = "Position: a weird place";
            typeText.GetComponent<Text>().text = "Type: Big star";
            pointer.GetComponent<Image>().enabled = true;
            Debug.Log(selected);
            //starSelected = true; 
        }
        else
        {
            //star.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            starName.GetComponent<Text>().text = "";
            distText.GetComponent<Text>().text = "";
            posText.GetComponent<Text>().text = "";
            typeText.GetComponent<Text>().text = "";
            pointer.GetComponent<Image>().enabled = false;
            Debug.Log(selected);
            //starSelected = false;
        }
    }
    void deselectStar()
    {
        Camera.main.DOFieldOfView(60, 2);
        starName.GetComponent<Text>().text = "";
        distText.GetComponent<Text>().text = "";
        posText.GetComponent<Text>().text = "";
        typeText.GetComponent<Text>().text = "";
        pointer.GetComponent<Image>().enabled = false;
        Debug.Log(starName);
        starSelected = false;
    }
    void selectStar()
    {
       //star.transform.localScale = new Vector3(4, 4, 4);
        starName.GetComponent<Text>().text = "Alpha Centauri";
        distText.GetComponent<Text>().text = "Distance: Far, far away";
        posText.GetComponent<Text>().text = "Position: a weird place";
        typeText.GetComponent<Text>().text = "Type: Big star";
        pointer.GetComponent<Image>().enabled = true;
        Debug.Log(starName);
        starSelected = true;
    }

    
}
