using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OpenPolterDialogue : MonoBehaviour
{
    bool showPromptOnce;
    bool startDialogue;
    bool showPolter;
    public GameObject player;
    public GameObject textEndIcon;
    public GameObject tutPromptBox;
    public GameObject williamSuspectInfo;
    public TextMesh tutPromptText;
    public Animator polterPad;
    public GameObject babyBottle;
    public UnityEvent pickBottleBack;
    // Start is called before the first frame update
    void Start()
    {
        tutPromptBox.SetActive(false);
        tutPromptText.text = "Polter_Info";
    }

    // Update is called once per frame
    void Update()
    {
        tutPromptBox.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        if (Input.GetKey(KeyCode.Tab))
        {
            tutPromptBox.SetActive(false);
            tutPromptText.text = "";
            polterPad.SetTrigger("");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!startDialogue) {
            if (Input.GetKey(KeyCode.E))
            {
                startDialogue = true;
            }
        }
        if (startDialogue)
        {
            if (textEndIcon == true)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    startDialogue = false;
                    if (showPolter)
                    {
                        if (showPromptOnce)
                        {
                            williamSuspectInfo.SetActive(true);
                            StartCoroutine(Dialogue());
                        }
                        babyBottle.GetComponent<Rigidbody>().useGravity = true;
                        showPolter = false;
                    }
                    else
                    {
                        if (showPromptOnce)
                        {
                            williamSuspectInfo.SetActive(true);
                            StartCoroutine(Dialogue());
                        }
                    }
                }
            }
        }
    }
    public void ShowPolter()
    {
        showPolter = true;
    }
    IEnumerator Dialogue()
    {
        tutPromptBox.SetActive(true);
        tutPromptText.text = "Press TAB to open PolterPad";
        yield return new WaitForSeconds(2f);
    }
}
