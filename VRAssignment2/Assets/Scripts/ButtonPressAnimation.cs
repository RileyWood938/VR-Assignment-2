using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimation : MonoBehaviour
{
    new Animator animator;
    new float TimeSincePlayback =0;
    new bool playbackStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playbackStarted = true)
        {
            TimeSincePlayback += Time.deltaTime;
            if (TimeSincePlayback > .54)
            {
                animator.SetBool("Pressed", false);
                playbackStarted = false;
           }
        }
       
       
    }
    public void pressed()
    {
        animator.SetBool("Pressed", true);
        playbackStarted = true;
        TimeSincePlayback = 0;
    }
}
