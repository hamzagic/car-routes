using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void Start() 
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        _scoreText.text = $"High Score: {highScore}";
    }
   public void PlayGame() {
       {
           SceneManager.LoadScene(1);
       }
   }
}
