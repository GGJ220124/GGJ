using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class JokeScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform ParentAfterDrag;
    public Image image;
    public TMP_Text text;
    LogicManager LogicManager;
    public JokeStats Joke;

    private void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
        
        Joke = LogicManager.GetJokeStat(); ;
        text.text = Joke.Joke;
        Debug.Log(LogicManager.mainManager.SelectedJokes.Count);
        Debug.Log(LogicManager.mainManager.AllJokes.Count);

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        text.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;
        text.raycastTarget = true;
    }

}
