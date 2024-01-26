using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectedJokes : MonoBehaviour, IDropHandler
{
    public string Joke = "EMPTY";
    GameObject dropped = null;
    JokeScript DragDrop;
    LogicManager LogicManager;
    public TMP_Text ErrorMessage;
    List<JokeStats> JokeStats = new List<JokeStats>();

    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount < 16)
        {
            dropped = eventData.pointerDrag;
            DragDrop = dropped.GetComponent<JokeScript>();
            DragDrop.ParentAfterDrag = transform;
            


            
        }

    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnBeginShowButtonClicked()
    {
        if (gameObject.transform.childCount == 16)
        {
            LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
            JokeStats.Clear();
            LogicManager.mainManager.ActiveJokes.Clear();
            LogicManager.mainManager.SelectedJokes.Clear();
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                
                LogicManager.mainManager.ActiveJokes.Add(transform.GetChild(i).GetComponent<JokeScript>().Joke);
                LogicManager.mainManager.SelectedJokes.Add(transform.GetChild(i).GetComponent<JokeScript>().Joke);


            }
            
            SceneManager.LoadScene(2);
        }
        else
        {
            ErrorMessage.text = "Please make sure you have 16 jokes selected!";
        }
        
    }

}
