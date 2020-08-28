using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnTimerOUt : MonoBehaviour
{
    int countdown;
    public GameObject player;
    public GameObject respawn;
    public GameObject body;
    public Animator blackScreen;
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Countdown()
    {
        for (int i = 60; i >= 0; i--)
        {
            yield return new WaitForSeconds(1f);
            if (i == 0)
            {
                body.SetActive(false);
                GameObject.Find("CFX2_WWExplosion_C").GetComponent<ParticleSystem>().Play();
                blackScreen.SetBool("Run_Fader", true);
                yield return new WaitForSeconds(2.5f);
                blackScreen.SetBool("Run_Fader", false);
                GameObject.Find("CFX2_WWExplosion_C").GetComponent<ParticleSystem>().Play();
                body.SetActive(true);
            }
        }
    }
}
