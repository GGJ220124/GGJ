using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropBoxScript : MonoBehaviour, IDropHandler
{
    public GameObject Spawner;
    public GameObject EndShowButton;
    string Joke = "EMPTY";
    GameObject dropped = null;
    JokeScript DragDrop;
    LogicManager LogicManager;
    public GameObject Canvas;
    List<JokeStats> UsedJokes = new List<JokeStats>();
    Vector3 Position = new Vector3(1629.248f, 681.9308f);
    int rounds = 0;




    void Start()
    {
        EndShowButton.SetActive(false);
        Instantiate(Spawner, Position, transform.rotation, Canvas.transform);
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        UsedJokes = LogicManager.mainManager.SelectedJokes;

    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {

            Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
            dropped = eventData.pointerDrag;
            DragDrop = dropped.GetComponent<JokeScript>();
            DragDrop.ParentAfterDrag = transform;
            Joke = dropped.GetComponentInChildren<TMP_Text>().text.ToString();
            Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
        }

    }
    private void Update()
    {
        if (rounds == 5)
        {
            EndShowButton.SetActive(true);
        }
        else if (rounds == 10)
        {
            EndShow();
        }
    }

    public void EndShow()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void OnClicked()
    {

        if (transform.childCount == 1)
        {
            rounds++;
            LogicManager.mainManager.SelectedJokes.Remove(DragDrop.Joke);
            
            Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
            LogicManager.CalculateEnjoyment(DragDrop.Joke);
            Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
            LogicManager.mainManager.ActiveJokes.Clear();
            foreach (var item in LogicManager.mainManager.SelectedJokes)
            {
                LogicManager.mainManager.ActiveJokes.Add(item);
            }
            //LogicManager.mainManager.ActiveJokes = SelectedJokesPlaceHolder;
            
            Debug.Log("NEW ACTIVE JOKES");
            Debug.Log(LogicManager.mainManager.ActiveJokes.Count);
            
            DestroyImmediate(Spawner);
            DestroyImmediate(dropped);

            Instantiate(Spawner, Position, transform.rotation, Canvas.transform);

        }
        else
        {
            Joke = "EMPTY";
        }

        




    }
}
