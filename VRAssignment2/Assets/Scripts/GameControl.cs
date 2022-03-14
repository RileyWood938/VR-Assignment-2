using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int score = 0;
    public Text scoreTracker;
    public GameObject[] screens;
    public GameObject[] buttons;
    public bool buttonSelection = false;
    public GameObject TentativeButton;
    public Material comparedColor;
    public bool level2;
    // Start is called before the first frame update
    void Start()
    {
        scoreTracker.text = "Score: " + score.ToString();
        //screens = new GameObject[];
        screens = GameObject.FindGameObjectsWithTag("Screen");
        RandomizeScreens();
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }
    public void RandomizeScreens()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            GameObject screen = screens[i];
            int r = Random.Range(0, i);
            screens[i] = screens[r];
            screens[r] = screen;
        }
        for(int i = 0; i < 3; i++)
        {
            screens[i].GetComponent<ScreenBehavior>().Slumber();
        }
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
                //Debug.Log("ButtonTied");
                TentativeButton.GetComponent<ButtonScript>().changeColor(screen.GetComponent<ScreenBehavior>().fetchColor());
                break;
            }
        }
    }

    public void checkButton(GameObject button)
    {
        
        for (int i = 0; i < screens.Length; i++)
        {
            
            if(screens[i].GetComponent<ScreenBehavior>().fetchColor() == button.GetComponent<ButtonScript>().fetchColor())
            {
                //Debug.Log("ScreenCleared");
                screens[i].GetComponent<ScreenBehavior>().SolvePredicament();
                button.GetComponent<ButtonScript>().switchColorToNormal();
                score += 10;
                if (score >= 100 && !level2)
                {
                    level2 = true;
                    foreach (GameObject screen in screens)
                    {
                        screen.GetComponent<ScreenBehavior>().Awake();
                    }
                }
                scoreTracker.text = "Score: " + score.ToString();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
