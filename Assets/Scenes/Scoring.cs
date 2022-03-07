using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public static Scoring Instance;

    public TMP_Text scoreText;

    private int scoreValue;
    public int Score
    {
        get => scoreValue;
        set
        {
            scoreValue = value;
            scoreText.text = scoreValue.ToString();
        }
    }
    private void Awake()
    {
        Instance = this;
        Score = 0;
    }

    public void UpdateHighScore()
    {
        var highScore = GetHighScore();
        if (Score > highScore)
        {
            SetHighScore(Score);
        }
    }
    public void SetHighScore(int highScore) => PlayerPrefs.SetInt(HighScoreKey, highScore);

    public int GetHighScore() => PlayerPrefs.GetInt(HighScoreKey, 0);

}
