using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    public GameObject starName;
    public GameObject distText;
    public GameObject posText;
    public GameObject typeText;
    public GameObject pointer;
    public Vector2 movement;
    public Vector3 checkPos;
    public Vector2 checkStarPos;
    public GameObject star;
    public float camPosX;
    public float camPosY;
    public calcSize size;
    public float halfOfFOV;
    private bool starSelected=false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        star = GameObject.Find("Star");
        starName = GameObject.FindGameObjectWithTag("starName");
        distText = GameObject.FindGameObjectWithTag("distText");
        posText = GameObject.FindGameObjectWithTag("posText");
        typeText = GameObject.FindGameObjectWithTag("typeText");
        pointer = GameObject.FindGameObjectWithTag("pointer");
        halfOfFOV = Camera.main.fieldOfView / 2;
        starSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        controlWithKeys();
        controlWithMouse();
    }
    void controlWithMouse(){
        camPosX = rb.transform.position.x;
        camPosY = rb.transform.position.y;
        checkPos = new Vector3(camPosX, camPosY, transform.position.z);
        checkStarPos = new Vector2(star.transform.position.x, star.transform.position.y);
        
        if (Input.GetMouseButton(0)){
            movement = new Vector2(Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));

            if ((camPosX < -((size.sizeX / 2) - halfOfFOV) && rb.velocity.x < 0) || (camPosX > (size.sizeX / 2) - halfOfFOV && rb.velocity.x > 0))
            {
                transform.position = new Vector3(checkPos.x * -1, checkPos.y, checkPos.z);
            }
            if ((camPosY < -((size.sizeY / 2) - halfOfFOV) && rb.velocity.y < 0) || (camPosY > (size.sizeY / 2) - halfOfFOV && rb.velocity.y > 0))
            {
                transform.position = new Vector3(checkPos.x, checkPos.y * 1, -checkPos.z);
            }
        }
        
        if(Mathf.Abs(camPosX-checkStarPos.x) <= 6 && Mathf.Abs(camPosY - checkStarPos.y) <= 6)
        {
            transform.position = Vector2.MoveTowards(transform.position, checkStarPos, 2.5f * Time.deltaTime);
            if (Input.GetMouseButtonDown(1))
            {
                starSelected = !starSelected;
                toggle(starSelected);
                
            }
            
        }
        

        
    }
    
    void controlWithKeys(){
        camPosX = rb.transform.position.x;
        camPosY = rb.transform.position.y;
        checkPos = new Vector3(camPosX, camPosY, transform.position.z);
        checkStarPos = new Vector2(star.transform.position.x, star.transform.position.y);
        

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if ((camPosX < -((size.sizeX / 2) - halfOfFOV) && rb.velocity.x < 0) || (camPosX > (size.sizeX / 2) - halfOfFOV && rb.velocity.x > 0))
        {
            transform.position = new Vector3(checkPos.x * -1, checkPos.y, checkPos.z);
        }
        if ((camPosY < -((size.sizeY / 2) - halfOfFOV) && rb.velocity.y < 0) || (camPosY > (size.sizeY / 2) - halfOfFOV && rb.velocity.y > 0))
        {
            transform.position = new Vector3(checkPos.x, checkPos.y * -1, checkPos.z);
        }

        if(Mathf.Abs(camPosX-checkStarPos.x) <= 6 && Mathf.Abs(camPosY - checkStarPos.y) <= 6)
        {
            transform.position = Vector2.MoveTowards(transform.position, checkStarPos, 2.5f * Time.deltaTime);
            if (Input.GetButtonDown("Jump"))
            {
                starSelected = !starSelected;
                toggle(starSelected);
            }
            
        }

        if (Input.GetButtonDown("Cancel"))
        {
            deselectStar();
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
    void toggle(bool selected){
        if(selected){
            star.transform.localScale = new Vector3(4, 4, 4);
            starName.GetComponent<Text>().text = "Alpha Centauri";
            distText.GetComponent<Text>().text = "Distance: Far, far away";
            posText.GetComponent<Text>().text = "Position: a weird place";
            typeText.GetComponent<Text>().text = "Type: Big star";
            pointer.GetComponent<Image>().enabled = true;
            Debug.Log(selected);
            //starSelected = true; 
        }else{
            star.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
        star.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
        star.transform.localScale = new Vector3(4, 4, 4);
        starName.GetComponent<Text>().text = "Alpha Centauri";
        distText.GetComponent<Text>().text = "Distance: Far, far away";
        posText.GetComponent<Text>().text = "Position: a weird place";
        typeText.GetComponent<Text>().text = "Type: Big star";
        pointer.GetComponent<Image>().enabled = true;
        Debug.Log(starName);
        starSelected = true;
    }
}
