using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tracks score/coin data
public class ScoreTracking : MonoBehaviour
{
    public int coinsPickedUp;
    private GamplayHUD _gamplayHud;
    public bool isDead = false;
    public int highScore;
    public int score;
    [SerializeField] private int scorePerSecond = 100;
    
    void Start()
    {
        InitializeSaveData();
        
        _gamplayHud = FindObjectOfType<GamplayHUD>();
        _gamplayHud.UpdateHighScoreUI(highScore);
        _gamplayHud.UpdateCoinText(coinsPickedUp);

        StartCoroutine(AddToScoreEverySecond());
    }

    void InitializeSaveData()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        
        if (PlayerPrefs.HasKey("coinsPickedUp"))
        {
            coinsPickedUp = PlayerPrefs.GetInt("coinsPickedUp");
        }
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        CheckIfNewHighScore();
        _gamplayHud.UpdateScoreText(score);
    }

    public void AddToScore()
    {
        score += scorePerSecond;
        CheckIfNewHighScore();
        _gamplayHud.UpdateScoreText(score);
        StartCoroutine(AddToScoreEverySecond());
    }

    //Score is Incremented every second while the player is alive
    IEnumerator AddToScoreEverySecond()
    {
        yield return new WaitForSeconds(1f);
        if (!isDead)
        {
            AddToScore();
        }
    }
    
    //When a coin is collected
    public void AddToCoinsPickedUp(int coinsAdded)
    {
        coinsPickedUp += coinsAdded;
        _gamplayHud.UpdateCoinText(coinsPickedUp);
    }

    //Check if the current score is the highest score yet and save it as the highscore if it is
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
