using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class JokeLocationScript : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            JokeScript Joke = dropped.GetComponent<JokeScript>();
            Joke.ParentAfterDrag = transform;
        }

    }



}
