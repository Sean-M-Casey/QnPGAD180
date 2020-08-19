using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public GameObject textBox;
    public GameObject[] iCircles;
    int[] iNums = {18, 19, 20, 21, 22, 23, 24, 25};
    TextWritingScript textScript;
    public GameObject textEndIcon;
    public GameObject player;
    int arrayTracker;
    bool eDown;
    bool mouseDown;
    void Start()
    {
        textScript = GameObject.Find("WorldScriptHolder").GetComponent<TextWritingScript>();
        for (int i = 0; i < iCircles.Length; i++)
        {
            iCircles[i].GetComponent<SpriteRenderer>().enabled = false;
        }
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
    }
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < iCircles.Length; i++)
        {
            if (other.name == iCircles[i].name)
            {
                iCircles[i].GetComponent<SpriteRenderer>().enabled = true;
                iCircles[i].GetComponent<Animator>().SetBool("White_Idle", true);
            }
        }
        if (mouseDown)
        {
            for (int i = 0; i < iCircles.Length; i++)
            {
                if (other.name == iCircles[i].name)
                {
                    textBox.SetActive(false);
                    textScript.chatText.text = "";
                    iCircles[i].GetComponent<Animator>().SetBool("White_FadeOut", true);
                    arrayTracker = i;
                    mouseDown = false;
                    StartCoroutine(TurnOffAfterAnim());
                }
            }
        }
        if (eDown)
        {
            for (int i = 0; i < iCircles.Length; i++)
            {
                if (other.name == iCircles[i].name)
                {
                    textScript.chatText.text = "";
                    textBox.SetActive(true);
                    textScript.triggerText(iNums[i]);
                    iCircles[i].GetComponent<Animator>().SetBool("White_ClickGreen", true);
                    eDown = false;
                }
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
}
