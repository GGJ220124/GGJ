using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audience_cheer : MonoBehaviour
{
    //Variables
    private bool on_floor = false;
    private float jump_height = 0.0f;
    public bool laugh_active = false;

    void Laugh()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump_height, 0);
        
     
    }

    private void Randomiser()
    {
        jump_height = Random.Range(10f, 20f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laugh_active == true & on_floor == true)
        {
            on_floor = false;
            Randomiser();
            Laugh();
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            on_floor = true;
        }

        
    }

}
