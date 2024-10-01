using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Score instance created.");
        }
        else
        {
            Debug.LogError("Multiple Score instances detected!");
        }
    }

    private void Start()
    {
        // Debug to check if TextMeshProUGUI references are assigned
        Debug.Log("CurrentScoreText is " + (_currentScoreText != null ? "assigned" : "not assigned"));
        Debug.Log("HighScoreText is " + (_highScoreText != null ? "assigned" : "not assigned"));
        
        _score = 0;  // Initialize score to 0
        _currentScoreText.text = _score.ToString();  // Display current score
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();  // Display high score

        Debug.Log("High Score in PlayerPrefs: " + PlayerPrefs.GetInt("HighScore", 0));
    }

    public void UpdateScore()
    {
        _score++;  // Increment score
        Debug.Log("Updating score, current score is: " + _score);
        
        _currentScoreText.text = _score.ToString();  // Update the score UI
        UpdateHighScore();  // Check if high score should be updated
    }

    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (_score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);  // Set new high score
            _highScoreText.text = _score.ToString();  // Update high score UI
            Debug.Log("New High Score: " + _score);
        }
    }
}
