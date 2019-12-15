using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformDependentUI : MonoBehaviour
{
    public Text tapToJump;
    public Text tapPlusHold;
    public Text tapToPlayAgain;
    public GameObject endScreen;
    private GameObject tapToJumpParent;
    private TimeScaleZero _timeScaleZero;
    void Start()
    {
        _timeScaleZero = FindObjectOfType<TimeScaleZero>();
        tapToJumpParent = tapToJump.gameObject.transform.parent.gameObject;
        

#if UNITY_ANDROID
        tapToJump.text = "TAP TO JUMP";
        tapPlusHold.text = "(TAP + HOLD FOR BIGGER JUMP";
        tapToPlayAgain.text = "(TAP TO PLAY AGAIN)";
#else
        tapToJump.text = "SPACE TO JUMP";
        tapPlusHold.text = "(SPACE + HOLD FOR BIGGER JUMP";
        tapToPlayAgain.text = "(PRESS 'SPACE' TO PLAY AGAIN)";
#endif
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && tapToJumpParent.activeSelf)
        {
            tapToJumpParent.SetActive(false);
            _timeScaleZero.SetTimeScaleOne();
        }

        if (Input.GetButtonDown("Jump") && endScreen.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
