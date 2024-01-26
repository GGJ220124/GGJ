using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject Star;
    List<GameObject> stars = new List<GameObject>();
    MainManager mainManager;
    int noStars = 0;
    public int test = 0;
    Vector3 StarPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManager>();
        StarPosition = transform.position;
        StarPosition.x -= 5;
        noStars = test / 20;
        Debug.Log(noStars);
        for (int i = 0; i < 5; i++) {
            Debug.Log("Help");
            GameObject s = Instantiate(Star, StarPosition, transform.rotation,transform);
            stars.Add(s);
            StarPosition.x += 2;
        }
        noStars = mainManager.AudienceEnjoyment / 20;
        for (int i = 1; i <= noStars; i++)
        {
            Debug.Log(i);
            int index = i - 1;
            transform.GetChild(index).GetComponent<StarScript>().changeToYellow = true;

        }


    }

    // Update is called once per frame
    

    public void MainMenuButtonClicked()
    {
        mainManager.Restart();
        SceneManager.LoadScene("MainMenu");
    }
    
}
