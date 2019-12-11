﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private GamplayHUD _gamplayHud;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell");
            _gamplayHud = FindObjectOfType<GamplayHUD>();
            _gamplayHud.IsDead();
            Destroy(other.gameObject);
        }
    }
}
