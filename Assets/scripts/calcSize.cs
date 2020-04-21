using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calcSize : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float sizeX;
    public float sizeY;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sizeX = sprite.bounds.size.x;
        sizeY = sprite.bounds.size.y;
    }
}
