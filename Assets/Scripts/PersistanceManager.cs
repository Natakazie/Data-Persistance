using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistanceManager : MonoBehaviour
{
    public int currentScore;
    public string currentName;
    List<Entry> highScores = new List<Entry>();
    public static PersistanceManager persistance;

    public List<Entry> HighScores
    {
        get
        {
            return highScores;
        }
    }
    private void Start()
    {

        if(persistance != null)
        {
            Destroy(gameObject);
            return;
        }
        LoadHighscores();
        persistance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void LoadHighscores()
    {
        string path = Application.persistentDataPath + "/highscores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreList l = JsonUtility.FromJson<ScoreList>(json);
            highScores = l.highscores;
            Debug.Log(json);
        }
    }

    public void ExportHighscores()
    {
        /*
        string json = "{\"highScores\": [" + JsonUtility.ToJson(highScores[0]);
        for(int i = 1; i< highScores.Count; i++){
            json = json +","+ JsonUtility.ToJson(highScores[i]);
        }
        json = json + "]}";
        */
        string json = JsonUtility.ToJson(new ScoreList(highScores));
        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
        if(File.Exists(Application.persistentDataPath + "/highscores.json"))
        {
            Debug.Log(Application.persistentDataPath + "/highscores.json");     
        }
        else
        {
            Debug.Log(("Failed"));
        }
    }

    public void AddNewHighScore()
    {
        highScores.Add(new Entry(currentScore, currentName));
        highScores.Sort( );
    }

    [System.Serializable]
    public class Entry : System.IComparable<Entry>
    {
        public Entry(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
        public int score;
        public string name;

        public int CompareTo(Entry e)
        {
            return score.CompareTo(e.score);
        }
    }
    [System.Serializable]
    class ScoreList
    {
        public List<Entry> highscores;
        public ScoreList(List<Entry> scores)
        {
            highscores = scores;
        }
    }

}
