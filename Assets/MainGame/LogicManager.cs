using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public MainManager mainManager;
    public List<JokeStats> ActiveJokes = new List<JokeStats>();
    public JokeStats RandomJoke;
    public int AudienceEnjoyment = 50;
    public int SelectedClub = 0;
    public int hated = 0;
    public bool Excellent = false;
    public bool Good = false;
    public bool Mid = false;
    public bool Bad = false;
    public GameObject Background;
    public Sprite SquareClub;
    public Sprite CircleClub;
    public Sprite HexagonClub;
    public Sprite TriangleClub;

    private void Awake()
    {
        
        mainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManager>();
        Debug.Log(mainManager.SelectedJokes.Count);
    }
    private void Start()
    {
        
        SelectedClub = mainManager.SelectedClub;
        Debug.Log(mainManager.SelectedJokes.Count);
        
        
    }
    private void Update()
    {

        switch (SelectedClub)
        {
            case 0:
                hated = 3;
                Background.GetComponent<SpriteRenderer>().sprite = SquareClub;
                break;
            case 1:
                hated = 2;
                Background.GetComponent<SpriteRenderer>().sprite = CircleClub;
                break;
            case 2:
                hated = 1;
                Background.GetComponent<SpriteRenderer>().sprite = TriangleClub;
                break;
            case 3:
                hated = 0;
                Background.GetComponent<SpriteRenderer>().sprite = HexagonClub;
                break;
            default:
                break;
        }
    }

    
    public JokeStats GetJokeStat()
    {
        Debug.Log(mainManager.SelectedJokes.Count);
        RandomJoke = mainManager.GetJokeStat();
        Debug.Log(mainManager.SelectedJokes.Count);
        return RandomJoke;
    }


    public void CalculateEnjoyment(JokeStats SelectedJoke)
    {
        List<int> Options = new List<int>() {0,1,2,3};
        Options.Remove(SelectedClub);
        Options.Remove(hated);
        int Enjoyment = ((SelectedJoke.Tastes[SelectedClub] * 2) + (SelectedJoke.Tastes[hated] * -2) + (SelectedJoke.Tastes[Options[0]]) + (SelectedJoke.Tastes[Options[1]])) / 5;
        Debug.Log(Enjoyment);
        AudienceEnjoyment += Enjoyment;
        Debug.Log("Audience Enjoyment:");
        Debug.Log(AudienceEnjoyment);
        if (Enjoyment >= 20)
        {
            Excellent = true;
        }
        else if (Enjoyment < 20 && Enjoyment >= 10)
        {
            Good = true;
        }
        else if (Enjoyment >= 10 && Enjoyment >= 1)
        {
            Mid = true;
        }
        else
        {
            Bad = true;
        }
        mainManager.AudienceEnjoyment = AudienceEnjoyment;
    }

}



