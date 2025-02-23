using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public List<ScoreData> highScores = new List<ScoreData>();
    public string playerName;

    void Awake()
    {
        // dont destroy
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScores.Add(new ScoreData(PlayerPrefs.GetString("PlayerName", "Player"), PlayerPrefs.GetInt("HighScore", 0)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHighScore(string playerName, int score)
    {
        highScores.Add(new ScoreData(playerName, score));
        highScores.Sort((x, y) => y.score.CompareTo(x.score));
        if (highScores.Count > 10)
        {
            highScores.RemoveRange(10, highScores.Count - 10);
        }

        PlayerPrefs.SetInt("HighScore", highScores[0].score);
        PlayerPrefs.SetString("PlayerName", highScores[0].playerName);
        PlayerPrefs.Save();
    }
}
