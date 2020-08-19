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
    bool openWavyArmsBool;
    bool shrugBool;

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

        if (textBox.activeSelf == true)
        {
            if (animationTracker == 1)
            {
                if (shrugBool == false)
                {
                    StartCoroutine(Shrug());
                }
            }
            else if (animationTracker == 2)
            {
                ResetAnimations();
                OpenMouth();
            }
            else if (animationTracker == 3)
            {
                ResetAnimations();
            }
            else if (animationTracker == 4 || animationTracker == 5)
            {
                if (openWavyArmsBool == false)
                {
                    StartCoroutine(OpenWavyArms());
                }
            }
            else if (animationTracker == 6)
            {
                ResetAnimations();
            }
            else if (animationTracker == 7)
            {
                if (shrugBool == false)
                {
                    StartCoroutine(Shrug());
                }
            }
            else if (animationTracker == 8)
            {
                ResetAnimations();
            }
            else if (animationTracker == 11)
            {
                if (shrugBool == false)
                {
                    StartCoroutine(Shrug());
                }
            }
            else if (animationTracker == 12)
            {
                OpenMouth();
            }
            else if (animationTracker == 13)
            {
                if (wavyArmsBool == false)
                {
                    StartCoroutine(WavyArms());
                }
            }
            else if (animationTracker == 14)
            {
                ResetAnimations();
            }
        }
    }

    IEnumerator WavyArms()
    {
        luccile.SetBool("Wavy_Arms_Bool", true);
        yield return new WaitForSeconds(2.5f);
        luccile.SetBool("Wavy_Arms_Bool", false);
        wavyArmsBool = true;
    }

    IEnumerator OpenWavyArms()
    {
        luccile.SetBool("Open_Wavy_Arms_Bool", true);
        yield return new WaitForSeconds(5f);
        luccile.SetBool("Open_Wavy_Arms_Bool", false);
        openWavyArmsBool = true;
    }

    IEnumerator Shrug()
    {
        luccile.SetBool("Shrug_Bool", true);
        yield return new WaitForSeconds(1f);
        luccile.SetBool("Shrug_Bool", false);
        shrugBool = true;

    }

    private void OpenMouth()
    {
        luccile.SetBool("Open_Mouth_Swap_Bool", true);
    }

    private void ResetAnimations()
    {
        luccile.SetBool("Open_Mouth_Swap_Bool", false);
        luccile.SetBool("Wavy_Arms_Bool", false);
        luccile.SetBool("Open_Wavy_Arms_Bool", false);
        luccile.SetBool("Shrug_Bool", false);
        openWavyArmsBool = false;
        wavyArmsBool = false;
        shrugBool = false;
    }

}
