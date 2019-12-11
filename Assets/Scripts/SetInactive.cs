using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("PlatformEnd")))
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if(other.CompareTag("Hazard") || other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
