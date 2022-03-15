using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimation : MonoBehaviour
{
    /// <summary>
    /// this script animates the buttons. It's called by the gaze over event
    /// </summary>
    
  
    //The method I used has a state machine which switches on press and switches back after the animation is complete.
    // It seems like there should be a more effeciaent approach but nothing else semmed to work

    new Animator animator; //find the animator
    new float TimeSincePlayback =0; //timer to control how long the animation plays for
    new bool playbackStarted = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// when the playback of the animation begins, the timer begins counting. after then animation is complete (.54) it switches back to the idle state
    /// </summary>
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

    /// <summary>
    /// this begins the animation by activating the state machine. It is triggered by a unity event
    /// </summary>
    public void pressed()
    {
        animator.SetBool("Pressed", true);
        playbackStarted = true;
        TimeSincePlayback = 0;
    }
}
