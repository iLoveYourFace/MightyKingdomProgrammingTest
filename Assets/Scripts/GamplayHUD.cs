using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Updating and displaying HUD and UI elements
public class GamplayHUD : MonoBehaviour
{
    //UI Objects
    public GameObject newHighScoreUI;
    public GameObject pauseButton;
    public GameObject endScreen;
    
    //Text Elements
    public Text coinsCollected;
    public Text scoreText;
    public Text highscoreText;
    public Text endScreenText;
    
    private int scoreCount;

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

    //Changes that happen when the player dies ie. Endscreen
    public void IsDead()
    {
        endScreenText.text = "YOU SCORED\n" + scoreCount + "\nBEFORE DYING";
        scoreText.text = "";
        endScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    //Save the new highscore 
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
