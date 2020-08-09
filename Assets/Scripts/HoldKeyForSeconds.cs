using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldKeyForSeconds : MonoBehaviour
{
    public GameObject[] glimpseItems;
    int currentItem;
    public GameObject[] followItems;
    public float keyHoldTime;
    public bool timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            timer = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < glimpseItems.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.name == glimpseItems[i].name)
                {
                    currentItem = i;
                    timer = true;
                    StartCoroutine(KeyHoldTimer());
                }
            }
        }
    }
    IEnumerator KeyHoldTimer()
    {
        yield return new WaitForSeconds(keyHoldTime);
        if (timer)
        {
            Debug.Log("Held");
            glimpseItems[currentItem].SetActive(false);
            glimpseItems[currentItem].GetComponent<Animator>().SetTrigger("Glimpse");           
        }
        else
        {
            Debug.Log("Fucked");
        }
    }
}
