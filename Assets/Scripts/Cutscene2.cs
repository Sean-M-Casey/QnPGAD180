using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2 : MonoBehaviour
{
    bool startCutscene2;
    public GameObject textBox;
    public GameObject textEndIcon;
    TextWritingScript textScript;
    int textTracker;
    bool mouseDown;
    // Start is called before the first frame update
    void Start()
    {
        textScript = gameObject.GetComponent<TextWritingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCutscene2)
        {
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
        if (mouseDown && textTracker == 27)
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
    }
    void Tutorial2()
    {

    }
    public void ReEnterFoyer()
    {
        startCutscene2 = true;
    }
    IEnumerator CutScene2()
    {
        textTracker = 27;
        yield return new WaitForSeconds(4f);
        textScript.chatText.text = "";
        textBox.SetActive(true);
        textScript.triggerText(textTracker);
    }
}
