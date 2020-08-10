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
    int arrayTracker;
    int itemsPicked= 0;
    bool playOnce;
    // Start is called before the first frame update
    void Start()
    {
        textScript = GameObject.Find("WorldScriptHolder").GetComponent<TextWritingScript>();
        for (int i = 0; i < iCircles.Length; i++)
        {
            iCircles[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        polterUI.SetActive(false);
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
            if (Input.GetKeyUp(KeyCode.E))
            {
                eDown = false;
            }
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
                Debug.Log("test");
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
        }
    }
    IEnumerator TurnOffAfterAnim()
    {
        yield return new WaitForSeconds(1f);
        iCircles[arrayTracker].GetComponent<SpriteRenderer>().enabled = false;
        iCircles[arrayTracker].GetComponent<Animator>().SetBool("White_FadeOut", false);
        iCircles[arrayTracker].GetComponent<Animator>().SetBool("White_ClickGreen", false);
    }
    void TriggerFoyerSound()
    {

    }
}
