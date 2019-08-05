using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] private float gameSpeed=1f;
    [SerializeField] private int pointsPerBlockDestroyed;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _currentScore;

    private int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            scoreText.text = _currentScore.ToString();
        }
    } 

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            CurrentScore = 0;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int scoreMultiplier)
    {
        CurrentScore += pointsPerBlockDestroyed* scoreMultiplier;
        
    }
}
