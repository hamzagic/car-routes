using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] int _scoreMultiplier = 10;

    public const string HighScoreKey = "HighScore";

    private float _score;

    private GameObject car;

    private bool moving;

    private void Start() 
    {
        GameObject obj = GameObject.Find("Canvas");
        car = GameObject.Find("Car");
    }

    void Update()
    {
        moving = car.GetComponent<Car>().IsMoving();
        if(!moving)
        {
            return;
        }
        _score += Time.deltaTime * _scoreMultiplier;
        _scoreText.text = Mathf.FloorToInt(_score).ToString();
    }

    private void OnDestroy() 
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (_score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(_score));
        }
    }
}
