using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cutscene2 : MonoBehaviour
{
    bool startCutscene2;
    public GameObject textBox;
    public GameObject textEndIcon;
    public Animator blackScreen;
    public GameObject stopWatchUI;
    public GameObject stopWatchUIHandle;
    public GameObject body;
    TextWritingScript textScript;
    public UnityEvent allowbabyBottle;
    bool finishBlackout;
    int textTracker;
    bool mouseDown;

    CutScene1 poofs;

    //The Below Variables allow for Victoria to spawn in, and leave the house
    public GameObject victoria;
    bool victoriaAnimationDone;
    
    // Start is called before the first frame update
    void Start()
    {
        textScript = gameObject.GetComponent<TextWritingScript>();
        victoriaAnimationDone = false;
        poofs = GameObject.Find("WorldScriptHolder").GetComponent<CutScene1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCutscene2)
        {
            GameObject.Find("Lucille").GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(CutScene2());
            startCutscene2 = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && textEndIcon.activeSelf)
        {
            mouseDown = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mouseDown = false;
        }
        if (mouseDown && textTracker == 27 && victoriaAnimationDone == true)
        {
            textTracker++;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
            mouseDown = false;
        }
        if (mouseDown && textTracker == 28)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
        }
        if (mouseDown && textTracker == 29)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
        }
        if (mouseDown && textTracker == 30)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
        }
        if (mouseDown && textTracker == 31)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
        }
        if (mouseDown && textTracker == 32)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
        }
        if (mouseDown && textTracker == 33)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(false);
            Tutorial2();
        }  
        if (mouseDown && textTracker == 34)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
        }
        if (mouseDown && textTracker == 35)
        {
            textTracker++;
            mouseDown = false;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(false);
            allowbabyBottle.Invoke();
            GameObject.Find("Lucille").GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    void Tutorial2()
    {
        body.SetActive(false);
        GameObject.Find("CFX2_WWExplosion_C").GetComponent<ParticleSystem>().Play();
        blackScreen.SetBool("Run_Fader", true);
        StartCoroutine(TurnOffFader());

    }
    IEnumerator TurnOffFader()
    {
        yield return new WaitForSeconds(2.5f);
        blackScreen.SetBool("Run_Fader", false);
        stopWatchUI.GetComponent<Animator>().SetBool("Stopwatch_Unpause", true);
        stopWatchUIHandle.GetComponent<Animator>().SetBool("Stopwatch_Unpause", true);
        GameObject.Find("CFX2_WWExplosion_C").GetComponent<ParticleSystem>().Play();
        body.SetActive(true);
        if (!finishBlackout)
        {
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(textTracker);
            finishBlackout = true;
        }
    }
    public void ReEnterFoyer()
    {
        startCutscene2 = true;
        Debug.Log("pleasestart");
    }
    IEnumerator CutScene2()
    {
        Debug.Log("please");
        textTracker = 27;
        victoria.SetActive(true);
        yield return new WaitForSeconds(2f);
        victoriaAnimationDone = true;
        victoria.SetActive(false);
        textScript.chatText.text = "";
        textBox.SetActive(true);
        textScript.triggerText(textTracker);
    }

}