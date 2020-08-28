using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene3 : MonoBehaviour
{
    TextWritingScript textScript;
    int[] iNums = {36, 37, 38, 39};
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
    public Animator william;
    public Animator floatingObjects;
    public Animator fader;
    public AudioSource playerCorrectSound;
    bool runTextOnce;
    // Start is called before the first frame update
    void Start()
    {
        textScript = gameObject.GetComponent<TextWritingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(textTracker);
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
            StartCoroutine(oneKeyOff());
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
        if (textTracker == 1)
        {
            if (spaceDown)
            {
                StartCoroutine(SpaceHeld());
            }
        }
        if (textTracker == 2)
        {
            if (eDown)
            {
                GameObject.Find("Baby_Circle").GetComponent<OpenPolterDialogue>().startDialogue = true;
                StartCoroutine(PeerInSoul());
                textBox.SetActive(false);
            }
        }
        if (textBox.activeSelf && textEndIcon.activeSelf && thisCutsceneActive)
        {
            if (mouseDown)
            {
                textScript.chatText.text = "";
                textBox.SetActive(false);
                if (textTracker == 0)
                {
                    StartCoroutine(runPrompt1());
                }
                if (textTracker == 2)
                {
                    tutPrompt.SetActive(true);
                    tutPromptBox.SetActive(true);
                    tutPromptText.text = "Hold ‘E’ to peer into Williams soul.";
                }
                if (textTracker == 3)
                {
                    fader.SetBool("Fade_Out", true);
                }
            }
        }
        if (enableMoan && oneKeyDown) {
            StartCoroutine(RunMoan());
        }
    }
    IEnumerator oneKeyOff()
    {
        yield return new WaitForSeconds(0.2f);
        oneKeyDown = false;
    }
    IEnumerator PeerInSoul()
    {
        if (eDown)
        {
            tutPrompt.SetActive(false);
            tutPromptBox.SetActive(false);
            tutPromptText.text = "";
            //start soul cutscene
            fader.SetBool("Run_Fader", true);
            yield return new WaitForSeconds(1f);
            fader.SetBool("Run_Fader", false);
            floatingObjects.SetBool("William is Possessed", true);
            yield return new WaitForSeconds(2f);
            //play noise
            yield return new WaitForSeconds(1f);
            textTracker = 3;
            textBox.SetActive(true);
            textScript.triggerText(iNums[textTracker]);
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
        tutPromptBox.transform.localScale = new Vector3(tutPromptBox.transform.localScale.x + 4, tutPromptBox.transform.localScale.y, tutPromptBox.transform.localScale.z);
        tutPromptText.transform.position = new Vector3(tutPromptText.transform.position.x - 2, tutPromptText.transform.position.y, tutPromptText.transform.position.z + 1f);
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
        textTracker = 1;
        william.SetBool("StartCry", true);
        GameObject.Find("Lucille").GetComponent<Animator>().SetBool("Wavy_Arms_Bool", true);
        yield return new WaitForSeconds(3f);
        GameObject.Find("Lucille").GetComponent<Animator>().SetBool("Wavy_Arms_Bool", false);
        if (!runTextOnce)
        {
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textBox.SetActive(true);
            textScript.triggerText(iNums[textTracker]);
            runTextOnce = true;
        }
    }
    IEnumerator RunCutscene3()
    {
        GameObject.Find("Lucille").GetComponent<Animator>().SetBool("Cutscene_Start", true);
        yield return new WaitForSeconds(4f);
        textScript.chatText.text = "";
        textScript.letterDelay = textScript.letterDelayDefault;
        textBox.SetActive(true);
        textScript.triggerText(iNums[textTracker]);
        thisCutsceneActive = true;
    }
    IEnumerator SpaceHeld()
    {
        if (spaceDown)
        {
            //start animator for billys bottle
            william.SetBool("StopCry", true);
            playerCorrectSound.Play();
            yield return new WaitForSeconds(2f);
            william.SetBool("StartPo", true);
            if (runTextOnce)
            {
                textTracker = 2;
                textScript.chatText.text = "";
                textScript.letterDelay = textScript.letterDelayDefault;
                textBox.SetActive(true);
                textScript.triggerText(iNums[textTracker]);
                runTextOnce = false;
            }
            GameObject.Find("Lucille").GetComponent<Animator>().SetBool("Cutscene_Start", false);
        }
        else
        {
            StopCoroutine(SpaceHeld());
        }
    }
}