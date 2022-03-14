using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehavior : MonoBehaviour
{

    float GracePeriod = 4.0f;
    float TrialGenerationInterval = 0.5f;
    bool countingGracePeriod = false;
    bool countingPredicament = false;
    public Material normal;
    public Material red;
    public Material orange;
    public Material yellow;
    public Material green;
    public Material blue;
    public Material purple;
    public Material[] colors;
    public Material colorOfProblem;
    public bool changed = false;
    public GameControl gameControl;
    public bool sleep = false;
    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("PlayerCamera").GetComponent<GameControl>();   
        countingGracePeriod = true;
        colors = new Material[] { red, orange, yellow, green, blue, purple };
    }
    public void StopAndRefresh()
    {
        GracePeriod = 4f;
        countingGracePeriod = false;

    }
    public void startCounting()
    {
        countingGracePeriod = true;
    }

    public void GeneratePredicament()
    {
        colorOfProblem = colors[Random.Range(0, 6)];
        GetComponent<Renderer>().material = colorOfProblem;
        changed = true;
        gameControl.tieButtons(gameObject);
        
    }

    public void SolvePredicament()
    {
        
        GetComponent<Renderer>().material = normal;
        changed = false;
        countingGracePeriod = true;
        colorOfProblem = normal;
    }

    public bool isChanged()
    {
        return changed;
    }

    public Material fetchColor()
    {
        return colorOfProblem;
    }

    public void Awake()
    {
        sleep = false;
    }
    public void Slumber()
    {
        sleep = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (countingGracePeriod && !sleep)
        {

            GracePeriod -= Time.deltaTime;
            if (GracePeriod <= 0)
            {
                StopAndRefresh();
                countingPredicament = true;
            }

        }
        if (countingPredicament)
        {
            if(TrialGenerationInterval > 0f)
            {
                TrialGenerationInterval -= Time.deltaTime;
            }
            else
            {
                TrialGenerationInterval = 0.5f;
                //Debug.Log("I am here");
                if(Random.Range(0, 2) > 0)
                {
                    countingPredicament = false;
                    GeneratePredicament();
                }
            }
                

        }
    }
}
