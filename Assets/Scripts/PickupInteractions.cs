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
    public GameObject stopWatchUIHandle;
    public GameObject polterProp;
    public GameObject stopWatchProp;
    public GameObject doorIcon;
    public GameObject tutPrompts;
    public GameObject tutPrompt1;
    public GameObject bottleGlimpse;
    public GameObject babyBottle;
    public GameObject player;
    public TextMesh tutText;
    int arrayTracker;
    int itemsPicked= 0;
    bool playOnce;
    bool allowBabyBottleInteract;
    bool fridgeFirst;
    bool pickupBottle;
    bool spaceDown;
    bool bottleFollow;

    //Sound effects//
    public AudioSource glimpseFeedback;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceDown = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            eDown = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceDown = false;
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
        if (bottleFollow)
        {
            babyBottle.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
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
                eDown = false;
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
                stopWatchUI.GetComponent<Animator>().SetBool("Stopwatch_Unpause", false);
                stopWatchUIHandle.GetComponent<Animator>().SetBool("Stopwatch_Unpause", false);
                stopWatchProp.SetActive(false);
                arrayTracker = 1;
                mouseDown = false;
                eDown = false;
                StartCoroutine(TurnOffAfterAnim());
            }
        }
        if (other.name == iCircles[2].name)
        {
            if (allowBabyBottleInteract)
            {
                iCircles[2].GetComponent<SpriteRenderer>().enabled = true;
                iCircles[2].GetComponent<Animator>().SetBool("White_Idle", true);
                if (eDown)
                {
                    if (fridgeFirst == false)
                    {
                        GameObject.Find("SM_Prop_Kitchen_Fridge_01").GetComponent<Animator>().SetBool("Is_Open", true);
                        tutPrompts.SetActive(true);
                        tutPrompt1.SetActive(true);
                        tutText.text = "Hold E on items with yellow rims to glimpse.";
                        iCircles[3].GetComponent<SpriteRenderer>().enabled = true;
                        iCircles[2].GetComponent<Animator>().SetBool("White_ClickGreen", true);
                        iCircles[3].SetActive(true);
                        eDown = false;
                        StartCoroutine(FridgeFirst());
                    }
                }
            }
        }
        if (other.name == iCircles[3].name)
        {
            if (eDown && fridgeFirst)
            {
                StartCoroutine(BabyBottle());
            }
            if (spaceDown && pickupBottle)
            {
                StartCoroutine(PickupBottle());
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
                fridgeFirst = false;
            }
            if (other.name == iCircles[3].name)
            {
                fridgeFirst = false;
            }
        }
    }
    IEnumerator PickupBottle()
    {
        Debug.Log("Testing1");
        yield return new WaitForSeconds(3f);
        if (spaceDown) {
            iCircles[3].SetActive(false);
            bottleFollow = true;
        }
        else {
            StopCoroutine(PickupBottle());
        }
    }
    IEnumerator FridgeFirst()
    {
        yield return new WaitForSeconds(0.5f);
        fridgeFirst = true;
    }
    IEnumerator BabyBottle()
    {
        yield return new WaitForSeconds(3f);
        if (eDown)
        {
            iCircles[3].GetComponent<Animator>().SetBool("White_ClickGreen", true);
            iCircles[3].GetComponent<Animator>().SetBool("White_FadeOut", true);
            StartCoroutine(TurnOffAfterAnim());
            StartCoroutine(StartGlimpse1());
        }
        else
        {
            StopCoroutine(BabyBottle());
        }
    }
    IEnumerator StartGlimpse1()
    {
        bottleGlimpse.SetActive(true);
        glimpseFeedback.Play();
        yield return new WaitForSeconds(5f);
        bottleGlimpse.SetActive(false);
        tutPrompts.SetActive(true);
        tutPrompt1.SetActive(true);
        tutPrompt1.transform.localScale = new Vector3(1.0934296f, 0.196026f, 0.3013142f);
        tutText.transform.position = new Vector3(tutText.transform.position.x - 0.045f, tutText.transform.position.y, tutText.transform.position.z - 0.01f);
        tutText.text = "Glimpses are spectral hints. Flash backs to moments";
        yield return new WaitForSeconds(3f);
        tutText.text = "Press TAB to open up the polter pad on the suspects tab.";
        yield return new WaitForSeconds(3f);
        tutText.text = "Click the Glimpses tab to review hints.";
        yield return new WaitForSeconds(3f);
        tutText.text = "Hold space to take glimpse objects with you.";
        yield return new WaitForSeconds(3f);
        GameObject.Find("Lucille").GetComponent<PlayerControls>().canMove = true;
        tutPrompt1.transform.localScale = new Vector3(0.7834296f, 0.196026f, 0.3013142f);
        tutText.text = "";
        tutPrompts.SetActive(false);
        tutPrompt1.SetActive(false);
        pickupBottle = true;
    }
    IEnumerator TurnOffAfterAnim()
    {
        yield return new WaitForSeconds(1f);
        iCircles[arrayTracker].GetComponent<SpriteRenderer>().enabled = false;
        iCircles[arrayTracker].GetComponent<Animator>().SetBool("White_FadeOut", false);
        iCircles[arrayTracker].GetComponent<Animator>().SetBool("White_ClickGreen", false);
        GameObject.Find("SM_Prop_Kitchen_Fridge_01").GetComponent<Animator>().SetBool("Is_Closed", false);
        eDown = false;
    }
    void TriggerFoyerSound()
    {
        Debug.Log("playSound");
        doorIcon.SetActive(true);
    }
    public void allowBaby()
    {
        allowBabyBottleInteract = true;
    }
}
