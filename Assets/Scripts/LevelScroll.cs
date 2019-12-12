using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    private float originalScrollSpeed;
    public float timeUntilScrollingIsSpedUp = 5f;
    public float speedToIncrementPercentage = 20f;
    private float playerRunSpeed = .5f;
    private float audioPitch = .8f;
    public Animator _animator;
    private SoundManager _soundManager;
    

    private void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        originalScrollSpeed = scrollSpeed;
        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        gameObject.transform.position += scrollSpeed * Time.deltaTime * Vector3.left;
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(timeUntilScrollingIsSpedUp);
        scrollSpeed += originalScrollSpeed * (speedToIncrementPercentage/100);
        playerRunSpeed += speedToIncrementPercentage / 100;
        audioPitch += speedToIncrementPercentage / 1000;
        _animator.SetFloat("RunSpeed", playerRunSpeed);
        _soundManager.ChangePitch("Theme", audioPitch);
        StartCoroutine(SpeedUp());
    }
}
