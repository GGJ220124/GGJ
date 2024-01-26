using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int AudienceEnjoyment = 50;
    public List<JokeStats> AllJokes = new List<JokeStats>();
    public List<JokeStats> SelectedJokes = new List<JokeStats>();
    public List<JokeStats> ActiveJokes = new List<JokeStats>();
    public int SelectedJokeCount = 0;
    public int SelectedClub = 0;
    public bool start = true; 

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
            


        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        

    }
    
    void Start()
    {
        Debug.Log("RAN");
        ReadFile();
        SelectJokes(AllJokes);
    }
    public void Restart()
    {
        ReadFile();
        SelectJokes(AllJokes);
    }


    private void Update()
    {
        SelectedJokeCount = SelectedJokes.Count;
    }

    public JokeStats GetJokeStat()
    {
        Debug.Log(SelectedJokes.Count);
        int random = Random.Range(0, ActiveJokes.Count);
        JokeStats RandomJoke = ActiveJokes[random];
        ActiveJokes.RemoveAt(random);
        Debug.Log(RandomJoke.Joke);
        return RandomJoke;
    }



    public void SelectJokes(List<JokeStats> Jokes)
    {
        SelectedJokes.Clear();
        ActiveJokes.Clear();
        Debug.Log(SelectedJokes.Count);
        Debug.Log(ActiveJokes.Count);
        foreach (var item in Jokes)
        {
            SelectedJokes.Add(item);
            ActiveJokes.Add(item);
        }
        Debug.Log(SelectedJokes.Count);
        Debug.Log(ActiveJokes.Count);
    }

    
    public void ReadFile()
    {
        try
        {
            AllJokes.Clear();
        }
        catch (System.Exception)
        {

            
        }
        var path = @"Assets\AllJokes.csv";
        string absolutePath = Path.GetFullPath(path);
        List<JokeStats> Jokes = new List<JokeStats>();
        if (File.Exists(absolutePath))
        {
            using (var reader = new StreamReader(absolutePath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    JokeStats NewJoke = new();
                    NewJoke.Joke = values[0];

                    NewJoke.Tastes[0] = int.Parse(values[1]);
                    NewJoke.Tastes[1] = int.Parse(values[2]);
                    NewJoke.Tastes[2] = int.Parse(values[3]);
                    NewJoke.Tastes[3] = int.Parse(values[4]);

                    AllJokes.Add(NewJoke);

                }
            }


        }

        
    }
}

public class JokeStats
{
    public string Joke;
    public int[] Tastes;
    public JokeStats()
    {
        Joke = string.Empty;
        Tastes = new int[4];
    }

}
