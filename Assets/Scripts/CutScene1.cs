using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutScene1 : MonoBehaviour
{
    public GameObject player;
    public GameObject textBox;
    public GameObject textEndIcon;
    public GameObject wasdSprites;
    public UnityEvent canMoveEvent;
    public UnityEvent pauseTimer;
    public UnityEvent unpauseTimer;
    TextWritingScript textScript;
    int textTracker = 0;
    bool finishCutscene;
    // Start is called before the first frame update
    void Start()
    {
        wasdSprites.SetActive(false);
        textScript = gameObject.GetComponent<TextWritingScript>();
        textBox.SetActive(false);
        StartCoroutine(Cutscene1());
    }
    void Update()
    {
        if (textTracker == 15 && !finishCutscene)
        {
            textScript.chatText.text = "";
            unpauseTimer.Invoke();
            textBox.SetActive(false);
            StartCoroutine(WASDShow());
            finishCutscene = true;
            //textTracker++;
        }
        else if (textTracker < 15)
        {
            textBox.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && textEndIcon.activeSelf == true && textTracker < 15)
        {
            StartCoroutine(Cutscene1());
            textTracker++;
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            textScript.letterDelay = 0.05f;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && textBox.activeSelf == true)
        {
            textScript.letterDelay = 0;
        }
        if (wasdSprites.activeSelf == true)
        {
            wasdSprites.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        }
        if (textBox.activeSelf == true)
        {
            player.GetComponent<PlayerControls>().canMove = false;
        }
        else
        {
            player.GetComponent<PlayerControls>().canMove = true;
        }
    }
    IEnumerator Cutscene1()
    {
        yield return new WaitForSeconds(0.07f);
        if (textTracker < 15)
        {
            textBox.SetActive(true);
            pauseTimer.Invoke();
        }
        textScript.triggerName(0);
        textScript.triggerText(textTracker);
    }
    IEnumerator WASDShow()
    {
        wasdSprites.SetActive(true);
        yield return new WaitForSeconds(2f);
        wasdSprites.SetActive(false);
    }
}
