using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamplayHUD : MonoBehaviour
{
    public Text scoreText;
    private int scoreCount;
    public Text highscoreText;
    public GameObject newHighScoreUI;
    

    public Text coinsCollected;
    public GameObject endScreen;
    public Text endScreenText;

    public void UpdateScoreText(int newScore)
    {
        scoreCount = newScore;
        scoreText.text = newScore.ToString();
    }
    
    public void UpdateCoinText(int newCoin)
    {
        PlayerPrefs.SetInt("coinsPickedUp", newCoin);
        coinsCollected.text = newCoin.ToString();
    }

    public void IsDead()
    {
        endScreenText.text = "YOU SCORED\n" + scoreCount + "\nBEFORE DYING";
        scoreText.text = "";
        endScreen.SetActive(true);
    }

    public void UpdateHighscore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highscoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        }
    }

    public void UpdateHighScoreUI(int highscore)
    {
        highscoreText.text = highscore.ToString();
    }

    public void EnableNewHighScoreUI()
    {
        newHighScoreUI.SetActive(true);
    }
}
