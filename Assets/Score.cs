using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;

    public Text scoreText;
    public Text homeBestScore;
    public Text homeGamesPlayed;

    public GameObject homeScreen;

    void Start()
    {
        ShowScore();

        scoreText.gameObject.SetActive(false);

        homeScreen.SetActive(true);

        homeBestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore");
        homeGamesPlayed.text = "GAMES PLAYED: " + PlayerPrefs.GetInt("GamesPlayed");
    }

    void Update()
    {
        
    }

    public void AddPoint()
    {
        score++;

        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        ShowScore();
    }

    public void AddGamePlayed()
    {
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
    }

    public void ShowScore()
    {
        scoreText.gameObject.SetActive(true);

        scoreText.text = score + "";
    }

    public void DisableHomeScreen()
    {
        homeScreen.SetActive(false);
    }
}
