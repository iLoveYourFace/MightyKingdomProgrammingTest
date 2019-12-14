using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{
    public int coinsPickedUp;
    private GamplayHUD _gamplayHud;
    public bool isDead = false;
    public int highScore;

    public int score;
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        
        _gamplayHud = FindObjectOfType<GamplayHUD>();
        _gamplayHud.UpdateHighScoreUI(highScore);
        
        if (PlayerPrefs.HasKey("coinsPickedUp"))
        {
            coinsPickedUp = PlayerPrefs.GetInt("coinsPickedUp");
        }
        
        _gamplayHud.UpdateCoinText(coinsPickedUp);
        
        _gamplayHud.UpdateCoinText(coinsPickedUp);
        StartCoroutine(AddToScoreEverySecond());
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        CheckIfNewHighScore();
        _gamplayHud.UpdateScoreText(score);
    }

    public void AddToScore()
    {
        score += 100;
        CheckIfNewHighScore();
        _gamplayHud.UpdateScoreText(score);
        StartCoroutine(AddToScoreEverySecond());
    }

    IEnumerator AddToScoreEverySecond()
    {
        yield return new WaitForSeconds(1f);
        if (!isDead)
        {
            AddToScore();
        }
    }
    
    public void AddToCoinsPickedUp(int coinsAdded)
    {
        coinsPickedUp += coinsAdded;
        _gamplayHud.UpdateCoinText(coinsPickedUp);
    }

    public void CheckIfNewHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            _gamplayHud.EnableNewHighScoreUI();
        }
    }
}
