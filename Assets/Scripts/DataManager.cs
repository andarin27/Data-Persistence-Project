using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public static DataManager instance;
    public string playerName = "New Player";        //Variable to be saved between scenes, but not for High Score
    public string highScorePlayer;                  //Name of the High Score Player
    public int highScore;                           //Point Value of the high score

    private void Awake()
    {
        if(instance!= null)                         //Ensure only one DataManager instance exists at a time
        {
            Destroy(gameObject);                    
            return;
        }
        instance = this;                            //Create new instance of DataManager
        DontDestroyOnLoad(gameObject);              //Preserve between scenes
        LoadHighScore();                            //Load Current High Score
    }
    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public string highScorePlayer;
        public int highScore;
    }
    public void SaveHighScore()
    {
        SaveData data=new SaveData();                                               //Create new SaveData variable
        data.highScorePlayer = highScorePlayer;                                     //Record High Score Player
        data.highScore = highScore;                                                 //Record High Score
        string json=JsonUtility.ToJson(data);                                       //Create json variable
        File.WriteAllText(Application.persistentDataPath+"/savefile.json",json);    //Convert data to json format and save to file
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";            //Path to previous data
        if (File.Exists(path))                                                      //Check if any previous data exists
        {
            string json = File.ReadAllText(path);                                   //Create json variable
            SaveData data = JsonUtility.FromJson<SaveData>(json);                   //Create SaveData from json
            highScorePlayer= data.highScorePlayer;                                  //Get Player Name for current high score
            highScore= data.highScore;                                              //Get current high score
        }
        else
        {
            highScore=0;                                                            //Set high score to 0 if no previous data exists
            highScorePlayer = "No High Score";                                      //Set High score player to "No High Score"
            Debug.Log("No Previous Data Available");                                //Display a debug log so you know no previous data exists
        }
    }
}
