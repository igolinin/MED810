using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class GameCrl_2 : MonoBehaviour
{
    [SerializeField]

    public TextMeshPro winTextFade;

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



    [SerializeField]
    public GameObject[] DeactivateObjects;

    public GameObject endText1;
    public GameObject endText2;
    public GameObject NextButton;


    // Update is called once per frame
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
            Invoke("showEndingScreen", 7);

        }

    }

    void fadeText()
    {
        winTextFade.DOFade(0, 2);
        NextButton.SetActive(true);

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

        endText1.SetActive(true);
        endText2.SetActive(true);
        NextButton.SetActive(true);

        Invoke("fadeText", 1);
        for (int i = 0; i < DeactivateObjects.Length; i++)
        {
            DeactivateObjects[i].SetActive(false);

        }
    }
}
