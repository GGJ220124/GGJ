using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudienceControl : MonoBehaviour
{
    //Variables
    LogicManager LogicManager;
    public bool on = false;
    public bool off = false;
    private int loop;
    private int Childnum = 0;
    public AudioClip[] excellent_sfx = {};
    public AudioClip[] good_sfx = { };
    public AudioClip[] mid_sfx = { };
    public AudioClip[] bad_sfx = { };
    private AudioClip[] clips = { };
    public int tier = 0;

    void Tier_Select()
    {
        if (LogicManager.Excellent == true) { clips = excellent_sfx; loop = 14; }
        else if (LogicManager.Good == true) { clips = good_sfx; loop = 7; }
        else if (LogicManager.Mid == true) { clips = mid_sfx; loop = 3; }
        else if (LogicManager.Bad == true) { clips = bad_sfx; loop = 0; }
        else { loop = 0; }
    }
    
    void Bounce()
    {
        List<int> childlist = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        for (int i = 0; i < loop; i++)
        {


            
            int RandomChild;
            int ChosenChild = 0;
            int x = 0;
            while (x != 1)
            {
                RandomChild = Random.Range(0, Childnum);
                if (childlist.Remove(RandomChild))
                {
                    ChosenChild = RandomChild;
                    x = 1;
                }
                else
                {
                    x = 0;
                    Debug.Log("duplicate!");
                }
            }

            transform.GetChild(ChosenChild).GetComponent<audience_cheer>().laugh_active = true;
            
            Debug.Log(ChosenChild);

        }
        Debug.Log("loop met");
        
      
    }


    // Start is called before the first frame update
    void Start()
    {
        Childnum = this.gameObject.transform.childCount;
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on == true)
        {
            on = false;
            Tier_Select();
            Bounce();
            int RandArrayElem = Random.Range(0, clips.Length);
            AudioClip clip = clips[RandArrayElem];
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
            
        }

        if (off == true)
        {
            for (int i = 0; i < Childnum; i++)
            {
                transform.GetChild(i).GetComponent<audience_cheer>().laugh_active = false;
                off = false;
            }
        }

        if (loop > Childnum) { loop = Childnum; }

    }
}
