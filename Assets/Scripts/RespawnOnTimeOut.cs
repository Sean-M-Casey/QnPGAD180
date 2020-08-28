using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTimeOut : MonoBehaviour
{
    public GameObject tutPrompt1;
    public GameObject tutPrompt2;
    public GameObject textBox;
    public GameObject stopWatch;
    public GameObject stopWatchAlert;
    public GameObject timerCountdown;
    public GameObject polter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutPrompt1.activeSelf || tutPrompt2.activeSelf || textBox.activeSelf || polter.activeSelf)
        {
            timerCountdown.GetComponent<RestartOnTimerOUt>().runOnce = false;
            stopWatch.GetComponent<Animator>().enabled = false;
            stopWatchAlert.GetComponent<Animator>().enabled = false;
        }
        else
        {
            timerCountdown.GetComponent<RestartOnTimerOUt>().runOnce = true;
            stopWatch.GetComponent<Animator>().enabled = true;
            stopWatchAlert.GetComponent<Animator>().enabled = true;
        }
    }
}
