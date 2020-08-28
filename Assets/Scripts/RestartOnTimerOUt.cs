using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnTimerOUt : MonoBehaviour
{
    public float countdown = 60;
    public GameObject player;
    public GameObject respawn;
    public GameObject body;
    public Animator blackScreen;
    public Animator Stopwatch;
    public Animator StopwatchHandle;
    public GameObject main_camera;
    public GameObject cam_pos_foyer;
    public RespawnOnTimeOut script;
    public bool runOnce;
    int i;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (runOnce)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown < 0 && blackScreen.GetBool("FadeOut") == false)
        {
            GameObject.Find("CFX2_WWExplosion_C").GetComponent<ParticleSystem>().Play();
            body.SetActive(false);
            player.transform.position = respawn.transform.position;
            GameObject.Find("Lucille").GetComponent<DoorScripts>().inRoom = "Foyer";
            main_camera.transform.position = cam_pos_foyer.transform.position;
            blackScreen.SetBool("Run_Fader", true);
            StartCoroutine(Teleport());
            countdown = 60;
            Stopwatch.SetBool("Stopwatch_Unpause", false);
            StopwatchHandle.SetBool("Stopwatch_Unpause", false);
            script.enabled = false;
            runOnce = false;
        }
    }
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2.5f);
        blackScreen.SetBool("Run_Fader", false);
        GameObject.Find("CFX2_WWExplosion_C").GetComponent<ParticleSystem>().Play();
        body.SetActive(true);
        Stopwatch.SetBool("Stopwatch_Unpause", true);
        StopwatchHandle.SetBool("Stopwatch_Unpause", true);
        runOnce = true;
        script.enabled = true;
    }
}
