using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{
    //make a singleton of game manager
    public static GameManager Instance;

    //public variable for how long the game is
    public int gameLength = 10;

    //float variable of the timer of the game
    public float timer = 0;

    //public var for text mesh pro obj
    public TextMeshPro displayText;

    private bool inGame = true;

    //private score var with a property
    //lower case is the variable
    private int score = 0;

    
    //Uppercase Score is the function
    public int Score
    {
        get //get score var
        {
            return score;
        }

        set //set the score var
        {
            score = value;
        }
    }
    //create a list of integers of high scores
    public List<int> highScores = new List<int>();

    private string FILE_PATH; //directory
    //has to be const so it cant be changed later
    private const string FILE_DIR = "/Data/"; //folder
    private const string FILE_NAME = "highScores.txt"; //file name
    
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null) //if there is no instance dont destroy on load
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else //if there already is then destroy this game object
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        //when game starts timer begins at 0
        timer = 0;

        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME; //path of directory
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)//in game is set to true so this code will always run
        {
            timer += Time.deltaTime;
            //what we want the display text to show, it shows timer: game length subtracted by timer
            //to show how much time is left
            displayText.text = "Timer: " + (gameLength - (int)timer);
        }

        if (timer >= gameLength && inGame) //if timer is greater than the game length dont increment timer
        {
            inGame = false; //set in game to false if it is greater than game legnth
            Debug.Log("Game Over");
            SceneManager.LoadScene("EndScreen");
            UpdateHighScores();
        }
    }

    void UpdateHighScores()
    {
        //take the highscores out of the file and put them in the highscores list
        if (highScores.Count == 0) //will check size of the list, so if there is nothing on the list
        {
            //if we already have high scores
            if (File.Exists(FILE_PATH))
            {
                //get the high scores from the file as a string
                string fileContents = File.ReadAllText(FILE_PATH); //save it in the string once its read
                
                //split the string into an array
                string[] fileSplit = fileContents.Split('\n');
                
                //go through all the strings that are numbers
                for (int i = 1; i < fileSplit.Length - 1; i++)
                {
                    //add the number(converted from a string) to highScores
                    highScores.Add(Int32.Parse(fileSplit[i]));
                }
            }
            else
            {
                //add a placeholder score
                highScores.Add(0);
            }
        }
        
        //insert our score into the high scores list, if its large enough
        for (int i = 0; i < highScores.Count; i++) //loop through all elements of array i
        {
            if (highScores[i] < Score) //if its less than the Score function
            {
                highScores.Insert(i, Score); //then insert a new score
                break; //ends the for loop once it finds what its looking for
            }
        }

        if (highScores.Count > 5) //if we have more than 5 high scores
        {
            //cut it to 5 scores
            highScores.RemoveRange(5, highScores.Count - 5);
        }
        //make a string of all high scores
        string highScoreStr = "High Scores: \n";

        for (int i = 0; i < highScores.Count; i++)//size of list
        {
            highScoreStr += highScores[i] + "\n"; //save all info into var highScoreString
        }
        
        //display high scores
        displayText.text = highScoreStr;

        File.WriteAllText(FILE_PATH, highScoreStr);
        
    }
    
    
}
