using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwapper : MonoBehaviour
{
    public CutScene1 script;
    public int animationTracker;
    public Animator luccile;
    public GameObject textBox;
    bool wavyArmsBool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTracker = script.textTracker;

        if (textBox.activeSelf == true)
        {
            luccile.SetBool("Cutscene_Start", true);
        }
        else if (textBox.activeSelf == false)
        {
            luccile.SetBool("Cutscene_Start", false);
        }

        if (animationTracker == 1)
        {
            if (wavyArmsBool == false)
            {
                StartCoroutine(WavyArms());
            }
        }
        else if (animationTracker == 2)
        {
            StopAllCoroutines();
            luccile.SetBool("Open_Mouth_Swap_Bool", true);
        }
    }

    IEnumerator WavyArms()
    {
        luccile.SetBool("Wavy_Arms_Bool", true);
        yield return new WaitForSeconds(2.5f);
        luccile.SetBool("Wavy_Arms_Bool", false);
        wavyArmsBool = true;
    }
}
