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
<<<<<<< Updated upstream
=======
    public bool level2;
    public Text text;
    private float tutorialTimer = 0;
    private bool tutorialDone = false;
    private bool levelTwoDisplayDone = false;
    private bool levelTwoDisplayStart = false;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        scoreTracker.text = "Score: " + score.ToString();
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

    public void checkButton(GameObject button)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if(screens[i].GetComponent<ScreenBehavior>().fetchColor() == button.GetComponent<ButtonScript>().fetchColor())
            {
                screens[i].GetComponent<ScreenBehavior>().SolvePredicament();
                button.GetComponent<ButtonScript>().switchColorToNormal();
                score += 10;
<<<<<<< Updated upstream
=======
                if (score >= 100 && !level2)
                {
                    level2 = true;
                    foreach (GameObject screen in screens)
                    {
                        screen.GetComponent<ScreenBehavior>().Awake();
                    }
                    
                    
                }
>>>>>>> Stashed changes
                scoreTracker.text = "Score: " + score.ToString();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        tutorialTimer += Time.deltaTime;
        updateUI();
    }
    
    public void updateUI()
    {
        if (!tutorialDone)
        {
            if (tutorialTimer > 4)
            {
                text.text = " ";
                tutorialDone = true;
            }
            else if (tutorialTimer > 2.5)
            {
                text.text = "Press the matching button to score points. ";
            }
            else if (tutorialTimer > .75)
            {
                text.text = "Screens will light up, connected to a button of the same color. ";   
            }
        }
        if (tutorialDone && !levelTwoDisplayDone)
        {
            if(level2 && !levelTwoDisplayStart)
            {
                text.text = "Level Two!";
                tutorialTimer = 0;
                levelTwoDisplayStart = true;
            }
            if(tutorialTimer> 1.5 && level2)
            {
                text.text = " ";
                levelTwoDisplayDone = true;
            }
        }
    }
}
