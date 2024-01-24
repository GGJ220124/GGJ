using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callout_Manager : MonoBehaviour
{
    //Variables
    public bool Excellent = false;
    public bool Good = false;
    public bool Mid = false;
    public bool Bad = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Excellent == true)
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).GetComponent<Animator>().ResetTrigger("Callout_anim");
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<Animator>().enabled = false;
        }

        if (Good == true)
        {
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }

        if (Mid == true)
        {
            gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        }

        if (Bad == true)
        {
            gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
