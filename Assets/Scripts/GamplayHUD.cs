using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamplayHUD : MonoBehaviour
{
    public Text score;

    public Text coinsCollected;
    public GameObject endScreen;

    public void UpdateScoreText(int newScore)
    {
        score.text = newScore.ToString();
    }
    
    public void UpdateCoinText(int newCoin)
    {
        coinsCollected.text = "Coins = " + newCoin.ToString();
    }

    public void IsDead()
    {
        endScreen.SetActive(true);
    }
}
