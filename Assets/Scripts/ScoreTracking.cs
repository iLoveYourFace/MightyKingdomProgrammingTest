using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{
    public int coinsPickedUp;
    private GamplayHUD _gamplayHud;

    public int score;
    void Start()
    {
        _gamplayHud = FindObjectOfType<GamplayHUD>();
        InvokeRepeating(nameof(AddToScore),0,1);
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        _gamplayHud.UpdateScoreText(score);
    }

    public void AddToScore()
    {
        score += 100;
        _gamplayHud.UpdateScoreText(score);
    }
    
    public void AddToCoinsPickedUp(int coinsAdded)
    {
        coinsPickedUp += coinsAdded;
        _gamplayHud.UpdateCoinText(coinsPickedUp);
    }
}
