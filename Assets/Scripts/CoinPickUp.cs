using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    private ScoreTracking _scoreTracking;
    public int coinValue = 1;
    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

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
