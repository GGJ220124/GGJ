using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCanvasScript : MonoBehaviour
{
    public AudioClip clip;

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
        // AudioClip clip = this.gameObject.GetComponent<AudioSource>().clip;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
