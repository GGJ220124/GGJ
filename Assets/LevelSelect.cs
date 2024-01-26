using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    LogicManager LogicManager;
    MainManager MainManager;
    // Start is called before the first frame update
    void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSquareClicked() {
        MainManager.SelectedClub = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void OnCircleClicked()
    {
        MainManager.SelectedClub = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnTriangleClicked()
    {
        MainManager.SelectedClub = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnHexagonClicked()
    {
        MainManager.SelectedClub = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
