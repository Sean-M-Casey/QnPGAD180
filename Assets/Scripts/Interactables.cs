using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public int interactAmounts;
    public GameObject[] interactCheck;
    GameObject currentObject;

    //Checks which interactable you are in range of and activates circle
    private void OnTriggerEnter(Collider other)
    {
            for (int i = 0; i < interactAmounts; i++)
            {
                if (interactCheck[i].name == other.name)
                {
                interactCheck[i].GetComponent<SpriteRenderer>().enabled = true;
                interactCheck[i].GetComponent<Animator>().SetTrigger("Trigger_Visible");
                }
            }
    }
    //if in the trigger and you press defined key, circle animation will trigger
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < interactAmounts; i++)
        {
            if (interactCheck[i].name == other.name)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    currentObject = interactCheck[i];
                    StartCoroutine(KeyInteract());
                }
            }
        }
    }
    private IEnumerator KeyInteract()
    {
        currentObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        currentObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    //When exiting Trigger circle is set to invisble
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < interactAmounts; i++)
        {
                interactCheck[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
