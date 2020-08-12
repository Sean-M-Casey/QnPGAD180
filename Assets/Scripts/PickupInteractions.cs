using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractions : MonoBehaviour
{
    bool eDown;
    bool mouseDown;
    public GameObject[] iCircles;
    int[] iNums = {25, 26};
    public GameObject textBox;
    TextWritingScript textScript;
    public GameObject textEndIcon;
    public GameObject polterUI;
    public GameObject stopWatchUI;
    public GameObject polterProp;
    public GameObject stopWatchProp;
    public GameObject doorIcon;
    public GameObject tutPrompts;
    public GameObject tutPrompt1;
    public TextMesh tutText;
    int arrayTracker;
    int itemsPicked= 0;
    bool playOnce;
    // Start is called before the first frame update
    void Start()
    {
        doorIcon.SetActive(false);
        textScript = GameObject.Find("WorldScriptHolder").GetComponent<TextWritingScript>();
        for (int i = 0; i < iCircles.Length; i++)
        {
            iCircles[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        polterUI.SetActive(false);
        iCircles[3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (textBox.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                eDown = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            eDown = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && textEndIcon.activeSelf)
        {
            mouseDown = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mouseDown = false;
        }
        if (itemsPicked == 2 && !playOnce)
        {
            TriggerFoyerSound();
            playOnce = !playOnce;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if  (other.name == iCircles[0].name)
        {
            iCircles[0].GetComponent<SpriteRenderer>().enabled = true;
            iCircles[0].GetComponent<Animator>().SetBool("White_Idle", true);
            if (eDown)
            {
                textScript.chatText.text = "";
                textScript.letterDelay = textScript.letterDelayDefault;
                textBox.SetActive(true);
                textScript.triggerText(iNums[0]);
                iCircles[0].GetComponent<Animator>().SetBool("White_ClickGreen", true);
                itemsPicked++;
                eDown = false;
            }
            if (mouseDown)
            {
                textBox.SetActive(false);
                textScript.chatText.text = "";
                iCircles[0].GetComponent<Animator>().SetBool("White_FadeOut", true);
                iCircles[0].GetComponent<SpriteRenderer>().enabled = false;
                polterUI.SetActive(true);
                polterProp.SetActive(false);
                arrayTracker = 0;
                mouseDown = false;
                StartCoroutine(TurnOffAfterAnim());
            }
        }
        if (other.name == iCircles[1].name)
        {
            iCircles[1].GetComponent<SpriteRenderer>().enabled = true;
            iCircles[1].GetComponent<Animator>().SetBool("White_Idle", true);
            if (eDown)
            {
                textScript.chatText.text = "";
                textScript.letterDelay = textScript.letterDelayDefault;
                textBox.SetActive(true);
                textScript.triggerText(iNums[1]);
                iCircles[1].GetComponent<Animator>().SetBool("White_ClickGreen", true);
                itemsPicked++;
                eDown = false;
            }
            if (mouseDown)
            {
                textBox.SetActive(false);
                textScript.chatText.text = "";
                iCircles[1].GetComponent<Animator>().SetBool("White_FadeOut", true);
                iCircles[1].GetComponent<SpriteRenderer>().enabled = false;
                stopWatchUI.SetActive(true);
                stopWatchProp.SetActive(false);
                arrayTracker = 1;
                mouseDown = false;
                StartCoroutine(TurnOffAfterAnim());
            }
        }
        if (other.name == iCircles[2].name)
        {
            iCircles[2].GetComponent<SpriteRenderer>().enabled = true;
            iCircles[2].GetComponent<Animator>().SetBool("White_Idle", true);
            if (eDown)
            {
                GameObject.Find("SM_Prop_Kitchen_Fridge_01").GetComponent<Animator>().SetBool("Is_Open", true);
                tutPrompts.SetActive(true);
                tutPrompt1.SetActive(true);
                tutText.text = "Hold E on items with yellow rims to glimpse.";
                iCircles[2].GetComponent<Animator>().SetBool("White_ClickGreen", true);
                iCircles[3].SetActive(true);
                eDown = false;
            }
        }
        if (other.name == iCircles[3].name)
        {
            iCircles[2].GetComponent<SpriteRenderer>().enabled = true;
            iCircles[2].GetComponent<Animator>().SetBool("White_Idle", true);
            if (eDown)
            {
                StartCoroutine(BabyBottle());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < iCircles.Length; i++)
        {
            if (other.name == iCircles[i].name)
            {
                iCircles[i].GetComponent<Animator>().SetBool("White_FadeOut", true);
                arrayTracker = i;
                StartCoroutine(TurnOffAfterAnim());
            }
            if (other.name == iCircles[2].name)
            {
                tutText.text = "";
                tutPrompts.SetActive(false);
                tutPrompt1.SetActive(false);
                GameObject.Find("SM_Prop_Kitchen_Fridge_01").GetComponent<Animator>().SetBool("Is_Open", false);
                GameObject.Find("SM_Prop_Kitchen_Fridge_01").GetComponent<Animator>().SetBool("Is_Closed", true);
                
            }
        }
    }
    IEnumerator BabyBottle()
    {
        yield return new WaitForSeconds(1f);
        if (eDown)
        {
            yield return new WaitForSeconds(1f);
            if (eDown)
            {
                yield return new WaitForSeconds(1f);
                if (eDown)
                {
                    StartCoroutine(StartGlimpse1());
                }
                else
                {
                    StopCoroutine(BabyBottle());
                }
            }
            else
            {
                StopCoroutine(BabyBottle());
            }
        }
        else
        {
            StopCoroutine(BabyBottle());
        }
    }
    IEnumerator StartGlimpse1()
    {
        //put animator things for glimpse here \/\/

        yield return new WaitForSeconds(5f);
        tutPrompts.SetActive(true);
        tutPrompt1.SetActive(true);
        tutText.text = "Glimpses are spectral hints. Flash backs to moments";
        yield return new WaitForSeconds(2f);
        tutText.text = "Press TAB to open up the polter pad on the suspects tab.";
        yield return new WaitForSeconds(2f);
        tutText.text = "Click the Glimpses tab to review hints.";
        yield return new WaitForSeconds(2f);
        tutText.text = "Hold space to take glimpse objects with you.";
        yield return new WaitForSeconds(2f);
        tutText.text = "";
        tutPrompts.SetActive(false);
        tutPrompt1.SetActive(false);
    }
    IEnumerator TurnOffAfterAnim()
    {
        yield return new WaitForSeconds(1f);
        iCircles[arrayTracker].GetComponent<SpriteRenderer>().enabled = false;
        iCircles[arrayTracker].GetComponent<Animator>().SetBool("White_FadeOut", false);
        iCircles[arrayTracker].GetComponent<Animator>().SetBool("White_ClickGreen", false);
        GameObject.Find("SM_Prop_Kitchen_Fridge_01").GetComponent<Animator>().SetBool("Is_Closed", false);
    }
    void TriggerFoyerSound()
    {
        Debug.Log("playSound");
        doorIcon.SetActive(true);
    }
}
