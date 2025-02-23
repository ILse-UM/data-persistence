using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text scoreText;
    public InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DataManager.Instance.highScores.Count; i++)
        {
            scoreText.text += DataManager.Instance.highScores[i].playerName + ": " + DataManager.Instance.highScores[i].score + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        DataManager.Instance.playerName = playerNameInput.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
