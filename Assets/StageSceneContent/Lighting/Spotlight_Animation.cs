using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Spotlight_Animation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Invoke("SetTrue", 3f);

    }

    void SetTrue()
    {
        this.gameObject.SetActive(true);
        AudioClip clip = this.gameObject.GetComponent<AudioSource>().clip;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
