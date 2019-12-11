using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private GamplayHUD _gamplayHud;
    private ScoreTracking _scoreTracking;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Hazard"))
        {
            Debug.Log("Player died");
            _gamplayHud = FindObjectOfType<GamplayHUD>();
            _scoreTracking = FindObjectOfType<ScoreTracking>();
            
            _gamplayHud.IsDead();
            _scoreTracking.isDead = true;
            Destroy(other.gameObject);
        }
    }
}
