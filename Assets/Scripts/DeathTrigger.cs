using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private GamplayHUD _gamplayHud;
    private ScoreTracking _scoreTracking;
    private SoundManager _soundManager;
    private TimeScaleZero _timeScaleZero;

    private void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        _gamplayHud = FindObjectOfType<GamplayHUD>();
        _scoreTracking = FindObjectOfType<ScoreTracking>();
        _timeScaleZero = FindObjectOfType<TimeScaleZero>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _soundManager.Play("Dead");
            _soundManager.StopSound("Theme");
            _soundManager.Play("DeadTheme");
            Debug.Log("Player died");
            _gamplayHud.IsDead();
            _timeScaleZero.SetTimeScaleZero();
            _scoreTracking.isDead = true;
            other.gameObject.SetActive(false);
        }
    }
}
