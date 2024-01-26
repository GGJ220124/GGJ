using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllJokes : MonoBehaviour, IDropHandler
{
    public GameObject Jokes;
    LogicManager LogicManager;
    public TMP_Text Joke;
    public TMP_Text Taste1;
    public TMP_Text Taste2;
    public TMP_Text Taste3;
    public TMP_Text Taste4;

    private void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        
        //LogicManager.mainManager.ReadFile();
        Debug.Log("ALL JOKES:");
        Debug.Log(LogicManager.mainManager.AllJokes.Count);
        for (int i = 0; i < LogicManager.mainManager.AllJokes.Count ; i++)
        {
            Instantiate(Jokes, transform.transform.position, transform.rotation, this.gameObject.transform);
        }
        
    }
    
   
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        JokeScript Joke = dropped.GetComponent<JokeScript>();
        Joke.ParentAfterDrag = transform;

    }

    private void Update()
    {
        
        Joke.text = transform.GetChild(0).GetComponent<JokeScript>().Joke.Joke;
        Taste1.text = transform.GetChild(0).GetComponent<JokeScript>().Joke.Tastes[0].ToString();
        Taste2.text = transform.GetChild(0).GetComponent<JokeScript>().Joke.Tastes[1].ToString();
        Taste3.text = transform.GetChild(0).GetComponent<JokeScript>().Joke.Tastes[2].ToString();
        Taste4.text = transform.GetChild(0).GetComponent<JokeScript>().Joke.Tastes[3].ToString();
    }

    public void BackButton()
    {
        transform.GetChild(transform.childCount-1).SetAsFirstSibling();
        Debug.Log("Back");
        
    }

    public void ForwardButton() {
        transform.GetChild(0).SetAsLastSibling();
        
        Debug.Log("Forward");
      
    }


}
