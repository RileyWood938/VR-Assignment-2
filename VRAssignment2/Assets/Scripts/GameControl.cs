using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject[] screens;
    public GameObject[] buttons;
    public bool buttonSelection = false;
    public GameObject TentativeButton;
    // Start is called before the first frame update
    void Start()
    {
        //screens = new GameObject[];
        screens = GameObject.FindGameObjectsWithTag("Screen");
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

    public void tieButtons(GameObject screen)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            GameObject but = buttons[i];
            int r = Random.Range(0, i);
            buttons[i] = buttons[r];
            buttons[r] = but;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            TentativeButton = buttons[i];
            if (TentativeButton.GetComponent<ButtonScript>().isChanged() == false)
            {
                TentativeButton.GetComponent<ButtonScript>().changeColor(screen.GetComponent<ScreenBehavior>().fetchColor());
                break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
