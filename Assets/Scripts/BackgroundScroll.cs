using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    private float originalScrollSpeed;
    private float timeUntilScrollingIsSpedUp; 
    private float speedToIncrementPercentage = 1f;
    private LevelScroll _levelScroll;

    private void Start()
    {
        _levelScroll = FindObjectOfType<LevelScroll>();
        originalScrollSpeed = scrollSpeed;
        timeUntilScrollingIsSpedUp = _levelScroll.timeUntilScrollingIsSpedUp;
        speedToIncrementPercentage = _levelScroll.speedToIncrementPercentage;
        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        gameObject.transform.position += scrollSpeed * Time.deltaTime * Vector3.left;

    }

    private void LateUpdate()
    {
        if (gameObject.transform.localPosition.x < -53)
        {
            gameObject.transform.localPosition += new Vector3(61.44f*1.5f, 0,0); 
        }
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(timeUntilScrollingIsSpedUp);
        scrollSpeed += originalScrollSpeed * (speedToIncrementPercentage/100);
        StartCoroutine(SpeedUp());
    }
}
