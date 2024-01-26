using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeSpawner : MonoBehaviour
{
    LogicManager LogicManager;
    public GameObject JokeLocation;
    List<JokeStats> Stats;
    Vector3 TopLeft = new Vector3 (800, 500, 0);
    Vector3 TopRight = new Vector3 (550, 500, 0);
    Vector3 BottomLeft = new Vector3 (800, 250, 0);
    Vector3 BottomRight = new Vector3(550, 250,0);
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
        Debug.Log(LogicManager.mainManager.ActiveJokes.Count);
        SpawnJokes();
        SpawnJokes();
        SpawnJokes();
        SpawnJokes();
        Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
        Debug.Log(LogicManager.mainManager.ActiveJokes.Count);
        Debug.Log("POSITION");
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
    }

    // Update is called once per frame
    

    public void SpawnJokes()
    {

        Instantiate(JokeLocation, transform.position, transform.rotation, this.gameObject.transform);
       
    }

    public void SaveUnusedJokes() {
        //Debug.Log(transform.childCount);
        Debug.Log(LogicManager.mainManager.ActiveJokes.Count);
        for (int i = 0; i < transform.childCount; i++)
        {
            LogicManager.mainManager.ActiveJokes.Add(transform.GetChild(i).GetChild(0).GetComponent<JokeScript>().Joke);
            Debug.Log(LogicManager.mainManager.ActiveJokes.Count);
            Destroy(transform.GetChild(i));
        }
    
    }
}
