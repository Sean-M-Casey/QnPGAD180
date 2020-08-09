using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWritingScript : MonoBehaviour
{
    public float letterDelayDefault;
    public float letterDelay;
    public string[] sentences;
    public string[] names;
    string message;
    public Text chatText;
    public Text nameText;
    public GameObject textEndIcon;
    int arrayTracker;
    // Start is called before the first frame update
    void Update()
    {
        if (chatText.text.Length >= sentences[arrayTracker].Length)
        {
            textEndIcon.SetActive(true);
        }
        else
        {
            textEndIcon.SetActive(false);
        }
    }
    public void triggerName(int nameArrayNum)
    {
        nameText.text = names[nameArrayNum];
    }
    public void triggerText(int arrayNum)
    {
        message = sentences[arrayNum];
        arrayTracker = arrayNum;
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
            foreach (char letter in message.ToCharArray())
            {
                chatText.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }
    }
}
