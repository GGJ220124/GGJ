using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AudienceControl : MonoBehaviour
{
    //Variables
    public bool on = false;
    public bool off = false;
    public int loop = 1;
    private int Childnum = 0;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on == true)
        {
            Bounce();
            on = false;
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
