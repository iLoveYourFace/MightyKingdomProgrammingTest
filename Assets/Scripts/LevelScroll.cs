using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float timeUntilScrollingIsSpedUp = 5f;
    [SerializeField] private float speedIncrementAmount = 1f;

    private void Start()
    {
        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        gameObject.transform.position += scrollSpeed * Time.deltaTime * Vector3.left;
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(timeUntilScrollingIsSpedUp);
        scrollSpeed += speedIncrementAmount;
        StartCoroutine(SpeedUp());
    }
}
