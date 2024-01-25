using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCanvasScript : MonoBehaviour
{
    
    public void OnEndShowButton()
    {
        gameObject.transform.GetChild(2).GetComponent<Animation>().Play();
        Invoke("Switch", 0.5f);
    }

    void Switch()
    {
        SceneManager.LoadScene("TempMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(1).GetComponent<Animation>().Play();
        AudioClip clip = this.gameObject.GetComponent<AudioSource>().clip;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
