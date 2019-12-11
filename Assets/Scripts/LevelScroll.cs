using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.position += Vector3.left * Time.deltaTime * 5;
    }
}
