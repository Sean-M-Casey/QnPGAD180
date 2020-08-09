using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SixtySeconds : MonoBehaviour
{
    public Animator timer;
    public Animator timerAlert;
    int timerStore = 60;
    public bool timerPause = false;
    public bool timeRestart = false;
    bool coroutineOn = true;
    IEnumerator co;
    void Start()
    {
        co = TimerCountdown();
        StartCoroutine(co);
    }
    private void Update()
    {
        //unpauses timer and world
        if (timerPause == false)
        {
            timer.enabled = true;
            timerAlert.enabled = true;
            StartCoroutine(co);
        }
        //properly restarts the timer coroutine
        if (coroutineOn == false)
        {
            StartCoroutine(co);
            coroutineOn = true;
        }
    }
    //Coroutine for Timer and Countdown
    public IEnumerator TimerCountdown()
    {
        for (int timeLeft = timerStore; timeLeft >= 0; timeLeft--)
        {
            //displays current timeLeft on UI
            yield return new WaitForSeconds(1f);
            //pauses timer and world
            if (timerPause == true)
            {
                timer.enabled = false;
                timerAlert.enabled = false;
                timerStore = timeLeft;
                StopCoroutine(co);
            }
            //triggers time restart and restarts coroutine
            if (timeRestart == true)
            {
                timerStore = 60;
                timeRestart = false;
                coroutineOn = false;
                StopCoroutine(co);
            }
        }
    }
    public void timePauseTrigger()
    {
        timerPause = true;
    }
    public void timeUnPauseTrigger()
    {
        timerPause = false;
    }
    public void timeRestartTrigger()
    {
        timeRestart = true;
    }
}
