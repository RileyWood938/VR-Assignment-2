using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int score = 0;
    public Text scoreTracker;
    public Text timeTracker;
    public GameObject[] screens;
    public GameObject[] buttons;
    public bool buttonSelection = false;
    public GameObject TentativeButton;
    public Material comparedColor;
    public bool level2;

    /// <summary>
    /// these variables used for the UI text display
    /// </summary>
    private float timer = 0; 
    public Text text;
    private bool tutoraialDone = false;
    private bool levelTwoDisplayDone = false;
    private bool levelTwoDisplayStart = false;

    public bool gameOver = false;
    public float timeCount = 180.0f;
    public bool quitTest = false;
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
                if (score >= 200 && !level2)
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
        timer += Time.deltaTime;
        updateUi();
        timeCount -= Time.deltaTime;
        if(timeCount <= 0)
        {
            gameOver = true;
        }
        if(timeCount <= 175f && quitTest)
        {
            gameOver = true;
        }
        
    }
    ///<summary>
    ///this method updates the UI, loading the tutorial scripts, hiding them after 2 seconds, and loading the "level two" text once we hit level two - riley
    ///</summary>
    private void updateUi()
    {
        if (!tutoraialDone)//check to make sure the tutorial hasn't already been completed
        {
            if (timer > 4)
            {
                text.text = " ";
                tutoraialDone = true;//mark the tutorial complete
            }else if(timer>2.5) {
                text.text = "Press the button of the same color to score points";
            }else if(timer>.75) {
                text.text = "These moniters will light up with a matching button";
            }
        }
        if (tutoraialDone && !levelTwoDisplayDone)
        {
            if (level2 && !levelTwoDisplayStart)
            {
                timer = 0;//on level two start reset the timer so the message only displays for 2 seconds
                text.text = "Level Two!";
                levelTwoDisplayStart = true;
            }
            if(levelTwoDisplayStart && timer > 2)
            {
                text.text = "";
                levelTwoDisplayDone = true;
            }

        }
        timeTracker.text = "Time remaining: 0" + Mathf.Floor((timeCount / 60)).ToString() + ":" + Mathf.Floor((timeCount % 60)).ToString();
        
    }
    void OnGUI()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;
            
            if (XRInputManager.IsButtonDown() || GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Game cleared. Totoal score: " + score.ToString()))
            {
                Application.Quit();
            }

        }
    }
}
