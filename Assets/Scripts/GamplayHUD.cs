using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamplayHUD : MonoBehaviour
{
    public Text score;
    private int scoreCount;

    public Text coinsCollected;
    public GameObject endScreen;
    public Text endScreenText;

    public void UpdateScoreText(int newScore)
    {
        scoreCount = newScore;
        score.text = newScore.ToString();
    }
    
    public void UpdateCoinText(int newCoin)
    {
        coinsCollected.text = newCoin.ToString();
    }

    public void IsDead()
    {
        endScreenText.text = "YOU SCORED " + scoreCount + " BEFORE DYING";
        score.text = "";
        endScreen.SetActive(true);
    }
}
