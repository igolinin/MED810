using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class GameCrl_2 : MonoBehaviour
{
    [SerializeField]


    public static bool info1Close;
    public static bool info2Close;
    public static bool info3Close;


    public TextMeshProUGUI primaryInfo;
    public TextMeshProUGUI secondaryInfo;
    public TextMeshProUGUI lensInfo;

    public Image primaryImage;
    public Image secondaryImage;
    public Image lensImage;
    public GameObject NextButton;
    public SpriteRenderer telescopeFinal;



    [SerializeField]
    public GameObject[] DeactivateObjects;

    [SerializeField]
    public SpriteRenderer[] LightBeams;

    public TextMeshProUGUI endText1;
    public TextMeshProUGUI endText2;


    // Update is called once per frame

    private void Start()
    {
        DOTween.SetTweensCapacity(7812, 50);
    }
    void Update()
    {
        //If the object is placed on the right spot
        if (Obj1_MouseMove.locked && info1Close == false)
        {
            primaryImage.DOFillAmount(1, 1);
            Invoke("fadePrimaryText", 1);
            info1Close = true;

        }
        else if (Obj2_MouseMove.locked && info2Close == false && info1Close == true)
        {
            secondaryImage.DOFillAmount(1, 1);
            primaryImage.DOFillAmount(0, 0.5f);
            primaryInfo.DOFade(0, 0.2f);
            Invoke("fadeSecondaryText", 1);
            info2Close = true;
        }
        else if (Obj3_MouseMove.locked && info3Close == false && info2Close == true)
        {
            lensImage.DOFillAmount(1, 1);
            secondaryImage.DOFillAmount(0, 0.5f);
            secondaryInfo.DOFade(0, 0.2f);

            Invoke("fadeLensText", 1);
            info3Close = true;
        }
        else if (Obj1_MouseMove.locked && Obj2_MouseMove.locked && Obj3_MouseMove.locked)
        {
            Invoke("showEndingScreen", 5);

        }

    }



    void fadePrimaryText()
    {
        primaryInfo.DOFade(1, 1);


    }

    void fadeSecondaryText()
    {
        secondaryInfo.DOFade(1, 1);
        


    }

    void fadeLensText()
    {
        lensInfo.DOFade(1, 1);


    }

    void showEndingScreen()
    {
        lensImage.DOFillAmount(0, 0.5f);
        lensInfo.DOFade(0, 0.2f);
        telescopeFinal.DOFade(1, 1);
        Invoke("fadeInDelay", 0.5f);

        for (int i = 0; i < LightBeams.Length; i++)
        {
            LightBeams[i].DOFade(0, 1);
        }

        for (int i = 0; i < DeactivateObjects.Length; i++)
        {
            DeactivateObjects[i].SetActive(false);

        }
    }
    void fadeInDelay()
    {
        NextButton.SetActive(true);
        endText1.DOFade(1, 1);
        endText2.DOFade(1, 2f);

    }
}
