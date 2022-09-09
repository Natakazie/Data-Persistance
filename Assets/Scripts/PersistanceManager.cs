using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public int currentScore;
    public string currentName;
    List<Entry> highScores = new List<Entry>();

    


    public void LoadHighscores()
    {

    }

    public void ExportHighscores()
    {
        string json = "[{\"highScores\": [";
        foreach(Entry e in highScores){
            json = json + "{name: " + e.name + ", score: " + e.score + "},";
        }
    }

    public void AddNewHighScore()
    {
        highScores.Add(new Entry(currentScore, currentName));
        highScores.Sort( );
    }

    [System.Serializable]
    class Entry : System.IComparable<Entry>
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
    class HighScoreFile
    {

    }
}
