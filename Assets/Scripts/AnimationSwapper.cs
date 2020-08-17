using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwapper : MonoBehaviour
{
    public CutScene1 script;
    int animationTracker;
    public Animator luccile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTracker = script.textTracker;

        if(animationTracker == 1 || animationTracker == 16 || animationTracker == 27)
        {
            luccile.SetBool("CutsceneStart", true);
        }
    }
}
