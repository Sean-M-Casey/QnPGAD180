﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PolterPadScript : MonoBehaviour
{
    public GameObject polterPad;
    public GameObject polterPadUI;
    public GameObject[] ppPages;
    public GameObject PageUp;
    public GameObject PageDown;
    public Animator timer;
    public Animator timerAlert;
    public UnityEvent triggerTimePause;
    public UnityEvent triggerTimeUnPause;
    public UnityEvent mouseLock;
    public GameObject textBox;
    int ppActive = 0;
    int ppPage = 0;
    //public Animator triggerPolterPad;
    void Start()
    {
        polterPad.SetActive(false);
    }
    void Update()
    {
        if (!textBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (ppActive == 0 && polterPadUI.activeSelf)
                {
                    StartCoroutine(ActivatePP());
                }
                if (ppActive == 1)
                {
                    timer.enabled = true;
                    timerAlert.enabled = true;
                    polterPad.SetActive(false);
                    polterPadUI.SetActive(true);
                    triggerTimeUnPause.Invoke();
                    ppActive--;
                    mouseLock.Invoke();
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            if (i != ppPage)
            {
                ppPages[i].SetActive(false);
            }
            else
            {
                ppPages[ppPage].SetActive(true);
            }
        }
    }
    public void UpArrow()
    {
            ppPage++;
            ppPages[ppPage - 1].SetActive(false);
            ppPages[ppPage].SetActive(true);
        if (ppPage == 1 || ppPage == 5 || ppPage == 7 || ppPage == 8)
        {
            PageUp.SetActive(false);
            PageDown.SetActive(true);
        }
        else
        {
            PageUp.SetActive(true);
            PageDown.SetActive(true);
        }
    }
    public void DownArrow()
    {
            ppPage--;
            ppPages[ppPage + 1].SetActive(false);
            ppPages[ppPage].SetActive(true);
        if (ppPage == 0 || ppPage == 2 || ppPage == 6 || ppPage == 8)
        {
            PageUp.SetActive(true);
            PageDown.SetActive(false);
        }
        else
        {
            PageUp.SetActive(true);
            PageDown.SetActive(true);
        }
    }
    public void SuspectsTab()
    {
        ppPage = 0;
        PageDown.SetActive(false);
        PageUp.SetActive(true);
    }
    public void GlimpsesTab()
    {
        ppPage = 2;
        PageDown.SetActive(false);
        PageUp.SetActive(true);
    }
    public void MapTab()
    {
        ppPage = 6;
        PageDown.SetActive(false);
        PageUp.SetActive(true);
    }
    public void CalendarTab()
    {
        ppPage = 8;
        PageDown.SetActive(false);
        PageUp.SetActive(false);
    }
    IEnumerator ActivatePP()
    {
        yield return new WaitForSeconds(0.2f);
        timer.enabled = false;
        timerAlert.enabled = false;
        polterPad.SetActive(true);
        PageDown.SetActive(false);
        polterPadUI.SetActive(false);
        triggerTimePause.Invoke();
        ppActive++;
        mouseLock.Invoke();
    }
}
