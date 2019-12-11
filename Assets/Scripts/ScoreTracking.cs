using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{
    public int coinsPickedUp;
    private GamplayHUD _gamplayHud;
    public bool isDead = false;

    public int score;
    void Start()
    {
        _gamplayHud = FindObjectOfType<GamplayHUD>();
        StartCoroutine(AddToScoreEverySecond());
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
}
