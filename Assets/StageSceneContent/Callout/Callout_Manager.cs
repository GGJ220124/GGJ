using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Callout_Manager : MonoBehaviour
{
    //Variables
    public bool Excellent = false;
    public bool Good = false;
    public bool Mid = false;
    public bool Bad = false;
    private int control = 0;
    private int num = 0;


    private void Reset()
    {
        Excellent = false;
        Good = false;
        Mid = false;
        Bad = false;
    }

    void PickChild()
    {
        if (Excellent == true) { num = 0; }
        else if (Good == true) { num = 1; }
        else if (Mid == true) { num = 2; }
        else if (Bad == true) { num = 3; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PickChild();
        if (Excellent == true || Good == true || Mid == true || Bad == true)
        {
            gameObject.transform.GetChild(num).GetComponent<SpriteRenderer>().enabled = true;
            if (control == 0)
            {
                gameObject.transform.GetChild(num).GetComponent<Animation>().Play();
                control = 1;
                Invoke("Reset", 1.4f);
            }

        }
        else
        {
            gameObject.transform.GetChild(num).GetComponent<SpriteRenderer>().enabled = false;
            control = 0;

        }
    }
}
