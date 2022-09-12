using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuUIManager : MonoBehaviour
{
    public Text nameInput;
    public TextMeshProUGUI highscores;
    bool checkedForHighscores;

    void Update()
    {
        if (!checkedForHighscores)
        {
            checkedForHighscores = true;
            List<PersistanceManager.Entry> scores = PersistanceManager.persistance.HighScores;
            if (scores.Count > 0)
            {
                Debug.Log("true");
                highscores.text = "";

                foreach (PersistanceManager.Entry e in scores)
                {
                    highscores.text = e.name + ": " + e.score + "\n" + highscores.text;
                }
                Debug.Log(highscores.text);
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                StartGame();
            }
        }
    }
    public void StartGame()
    {
        PersistanceManager.persistance.currentName = nameInput.text;
        SceneManager.LoadScene(1);
    }

}
