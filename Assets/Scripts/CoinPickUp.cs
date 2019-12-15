using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When the player picks up a coin
public class CoinPickUp : MonoBehaviour
{
    private ScoreTracking _scoreTracking;
    private SoundManager _soundManager;
    
    //How much will the coin give you
    public int coinValue = 1;

    private void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    //When the player picks up a coin, update the how many you have, play a sound and destroy the coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _soundManager.Play("Coin");
            _scoreTracking = FindObjectOfType<ScoreTracking>();
            _scoreTracking.AddToCoinsPickedUp(coinValue);
            _scoreTracking.AddToScore(500);
            Destroy(gameObject);
        }
    }
}
