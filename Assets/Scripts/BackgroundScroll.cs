using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For the paralax effect in the background of the level
public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    private float originalScrollSpeed;
    private float timeUntilScrollingIsSpedUp; 
    private float speedToIncrementPercentage = 1f;
    
    //We need to match the changes of the platform movement speeds for the best effect
    private LevelScroll _levelScroll;

    private void Start()
    {
        _levelScroll = FindObjectOfType<LevelScroll>();
        originalScrollSpeed = scrollSpeed;
        timeUntilScrollingIsSpedUp = _levelScroll.timeUntilScrollingIsSpedUp;
        speedToIncrementPercentage = _levelScroll.speedToIncrementPercentage;
        StartCoroutine(SpeedUp());
    }

    //Move the object
    void Update()
    {
        gameObject.transform.position += scrollSpeed * Time.deltaTime * Vector3.left;
    }

    //When the object is move off screen, move it to the other side so it can scroll past again
    private void LateUpdate()
    {
        if (gameObject.transform.localPosition.x < -53)
        {
            gameObject.transform.localPosition += new Vector3(61.44f*1.5f, 0,0); 
        }
    }

    //Speed up how fast the object is moving
    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(timeUntilScrollingIsSpedUp);
        scrollSpeed += originalScrollSpeed * (speedToIncrementPercentage/100);
        StartCoroutine(SpeedUp());
    }
}
