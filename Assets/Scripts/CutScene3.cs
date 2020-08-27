using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene3 : MonoBehaviour
{
    TextWritingScript textScript;
    int[] iNums = {36, 37, 38};
    public GameObject textBox;
    public GameObject textEndIcon;
    int textTracker = 0;
    bool mouseDown;
    bool oneKeyDown;
    bool spaceDown;
    bool eDown;
    bool enableMoan;
    bool thisCutsceneActive;
    public TextMesh tutPromptText;
    public GameObject tutPromptBox;
    public GameObject tutPrompt;
    // Start is called before the first frame update
    void Start()
    {
        textScript = gameObject.GetComponent<TextWritingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eDown = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            eDown = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceDown = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            oneKeyDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            oneKeyDown = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouseDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mouseDown = false;
        }
        if (textBox.activeSelf && textEndIcon.activeSelf && thisCutsceneActive)
        {
            if (mouseDown)
            {
                textScript.chatText.text = "";
                textBox.SetActive(false);
                if (textTracker == 1)
                {
                    StartCoroutine(runPrompt1());
                }
                if (textTracker == 2)
                {
                    if (spaceDown)
                    {
                        StartCoroutine(SpaceHeld());
                    }
                }
                if (textTracker == 3)
                {
                    tutPrompt.SetActive(true);
                    tutPromptBox.SetActive(true);
                    tutPromptText.text = "Hold ‘E’ to peer into Williams soul.";
                    if (eDown)
                    {
                        StartCoroutine(PeerInSoul());
                    }
                }
            }
        }
        if (enableMoan && oneKeyDown) {
            StartCoroutine(RunMoan());
        }
    }
    IEnumerator PeerInSoul()
    {
        yield return new WaitForSeconds(3f);
        if (eDown)
        {
            tutPrompt.SetActive(false);
            tutPromptBox.SetActive(false);
            tutPromptText.text = "";
            //start soul cutscene
        }
        else
        {
            StopCoroutine(PeerInSoul());
        }
    }
    IEnumerator runPrompt1()
    {
        tutPrompt.SetActive(true);
        tutPromptBox.SetActive(true);
        tutPromptText.text = "Lucille is a ghost, time to make her act like one. Press 1 to do her Ghost Moan.";
        yield return new WaitForSeconds(2f);
        tutPrompt.SetActive(false);
        tutPromptBox.SetActive(false);
        tutPromptText.text = "";
        enableMoan = true;
    }
    public void RunCutScene()
    {
        StartCoroutine(RunCutscene3());
    }
    IEnumerator RunMoan()
    {
        GameObject.Find("Lucille").GetComponent<Animator>().SetBool("Wavy_Arms_Bool", true);
        yield return new WaitForSeconds(3f);
        GameObject.Find("Lucille").GetComponent<Animator>().SetBool("Wavy_Arms_Bool", false);
        textScript.chatText.text = "";
        textScript.letterDelay = textScript.letterDelayDefault;
        textBox.SetActive(true);
        textScript.triggerText(iNums[textTracker]);
        textTracker++;
    }
    IEnumerator RunCutscene3()
    {
        yield return new WaitForSeconds(4f);
        textScript.chatText.text = "";
        textScript.letterDelay = textScript.letterDelayDefault;
        textBox.SetActive(true);
        textScript.triggerText(iNums[textTracker]);
        textTracker++;
        thisCutsceneActive = true;
    }
    IEnumerator SpaceHeld()
    {
        yield return new WaitForSeconds(3f);
        if (spaceDown)
        {
            //start animator for billys bottle

            yield return new WaitForSeconds(2f);
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(iNums[textTracker]);
            textTracker++;
        }
        else
        {
            StopCoroutine(SpaceHeld());
        }
    }
}