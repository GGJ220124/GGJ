using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite YellowStar;
    public bool changeToYellow = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (changeToYellow)
        {
            spriteRenderer.sprite = YellowStar;
        }
    }
    
}
