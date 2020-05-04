using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class animationController : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer beam1;
    public SpriteRenderer beam2;

    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;

    void Start()
    {

        Text1.DOFade(1, 2f);
        Text2.DOFade(1, 2f);
        Text3.DOFade(1, 2f);
    

        Invoke("fadeInBeams", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void fadeInBeams()
    {
        beam1.DOFade(1, 1f);
        beam2.DOFade(1, 1f);

        Debug.Log("HELLO MR ANIMATION");
    }



}
