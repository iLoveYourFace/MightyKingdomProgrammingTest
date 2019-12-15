using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Despawns objects that hit the trigger off the screen
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
        else if(other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
