using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimation : MonoBehaviour
{
    new Animator animator;
    new bool lookedAt = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && lookedAt)
        {
            animator.SetBool("Pressed", true);
        }
        else
        {
            animator.SetBool("Pressed", false);
        }
    }
    public void pressed()
    {
        animator.SetBool("Pressed", true);
    }
    public void GazeOver()
    {
        lookedAt = true;
    }
    public void GazeEnd()
    {
        lookedAt = false;
    }
}
