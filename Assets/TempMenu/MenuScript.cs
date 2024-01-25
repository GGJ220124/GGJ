using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnPlayButton()
    {
        gameObject.transform.GetChild(2).GetComponent<Animation>().Play();
        Invoke("Switch", 0.5f);
    }

    void Switch()
    {
        SceneManager.LoadScene("Performance");
    }

    void Start()
    {
        gameObject.transform.GetChild(3).GetComponent<Animation>().Play();
    }
}
