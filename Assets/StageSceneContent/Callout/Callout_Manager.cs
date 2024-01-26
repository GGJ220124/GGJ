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
    LogicManager LogicManager;
    private int control = 0;
    private int num = 0;


    private void Reset()
    {
        LogicManager.Excellent = false;
        LogicManager.Good = false;
        LogicManager.Mid = false;
        LogicManager.Bad = false;
        GameObject.Find("AudienceBody").GetComponent<AudienceControl>().off = true;
    }

    void PickChild()
    {
        if (LogicManager.Excellent == true) { num = 0; }
        else if (LogicManager.Good == true) { num = 1; }
        else if (LogicManager.Mid == true) { num = 2; }
        else if (LogicManager.Bad == true) { num = 3; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        PickChild();
        if (LogicManager.Excellent == true || LogicManager.Good == true || LogicManager.Mid == true || LogicManager.Bad == true)
        {
            gameObject.transform.GetChild(num).GetComponent<SpriteRenderer>().enabled = true;
            if (control == 0)
            {
                gameObject.transform.GetChild(num).GetComponent<Animation>().Play();
                GameObject.Find("AudienceBody").GetComponent<AudienceControl>().on = true;
                control = 1;
                Invoke("Reset", 1.4f);
            }

        }
        else
        {
            gameObject.transform.GetChild(num).GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AudienceBody").GetComponent<AudienceControl>().off = true;
            control = 0;

        }
    }
}
