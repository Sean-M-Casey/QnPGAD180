using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallMoveScene : MonoBehaviour
{
    public GameObject wallTrigger;
    public GameObject wallGlow;
    public GameObject WASD;
    public GameObject textBox;
    public GameObject player;
    public GameObject tutPrompts;
    public GameObject textEndIcon;
    PlayerControls playerControls;
    public TextMesh tutPromptText;
    TextWritingScript textScript;
    public string[] tutPromptMsg;
    bool continueOne;
    int textTracker = 15;
    bool isColliding;
    bool wallFlashHasRun;
    bool wallCollideFirst;
    bool wallRunCollideDone;
    bool wallCollideComplete = false;
    GameObject tutPrompt1;
    GameObject tutPrompt2;
    // Start is called before the first frame update
    void Start()
    {
        tutPrompt1 = GameObject.Find("TutPromptBox1");
        tutPrompt2 = GameObject.Find("TutPromptBox2");
        tutPrompts.SetActive(false);
        textScript = GameObject.Find("WorldScriptHolder").GetComponent<TextWritingScript>();
        playerControls = player.GetComponent<PlayerControls>();
        wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutPromptText.text == tutPromptMsg[0])
        {
            tutPrompts.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        }
        if (WASD.activeSelf == false && textBox.activeSelf == false)
        {
            StartCoroutine(turnOnFlash());
            if (wallFlashHasRun)
            {
                StartCoroutine(WallFlash());
            }
        }
        else
        {
            wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
        }
        if (textEndIcon.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (continueOne && textTracker < 16)
                {
                    textBox.SetActive(false);
                    playerControls.canMove = true;
                    tutPromptText.text = tutPromptMsg[0];
                    tutPrompt2.SetActive(true);
                    StartCoroutine(WallFlash2());
                }
                if (textTracker == 16)
                {
                    textBox.SetActive(true);
                    textScript.chatText.text = "";
                    textTracker += 1;
                    textScript.triggerText(textTracker);
                }
                if (textTracker == 17 && textScript.chatText.text.Length == textScript.sentences[textTracker].Length)
                {
                    textBox.SetActive(false);
                    playerControls.canMove = true;
                    StartCoroutine(DoorFlash());
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == "Foyer_Wall 1")
        {
            continueOne = true;
            playerControls.canMove = false;
            textBox.SetActive(true);
            textScript.chatText.text = "";
            textScript.triggerText(textTracker);
        }
        if (collide.gameObject.name == "Foyer_Wall 3")
        {
            if (!wallCollideComplete)
            {
                //if (wallRunCollideDone)
                //{
                    tutPrompts.SetActive(false);
                    textScript.chatText.text = "";
                    textTracker += 1;
                    textBox.SetActive(true);
                    textScript.triggerText(textTracker);
                    wallCollideComplete = true;
                //}
            }
        }
    }
    //private void OnCollisionExit(Collision collide)
    //{
    //    if (collide.gameObject.name == "Foyer_Wall 1")
    //    {
    //        isColliding = false;
    //    }
    //}
    //IEnumerator WallPrompt1()
    //{
    //    yield return new WaitForSeconds(5f);
    //    if (!continueOne)
    //    {
    //        if (isColliding)
    //        {
    //            continueOne = true;
    //            playerControls.canMove = false;
    //            textBox.SetActive(true);
    //            textScript.chatText.text = "";
    //            textScript.triggerText(textTracker);
    //        }
    //    }
    //}
    IEnumerator DoorFlash()
    {
        GameObject.Find("Foyer_Door_Kitchen").GetComponent<Animator>().SetBool("startGlow", true);
        yield return new WaitForSeconds(5f);
        GameObject.Find("Foyer_Door_Kitchen").GetComponent<Animator>().SetBool("startGlow", false);
    }
    IEnumerator WallFlash2()
    {
        GameObject.Find("Foyer_Wall 3").GetComponent<Animator>().SetBool("startGlow", true);
        yield return new WaitForSeconds(5f);
        GameObject.Find("Foyer_Wall 3").GetComponent<Animator>().SetBool("startGlow", false);
        wallRunCollideDone = true;
    }
    IEnumerator WallFlash()
    {
            wallGlow.GetComponent<Animator>().SetBool("startGlow", true);
            yield return new WaitForSeconds(5f);
            wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
    }
    IEnumerator turnOnFlash()
    {
        yield return new WaitForSeconds(1f);
        wallFlashHasRun = true;
    }
}
