using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject[] screens;
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        //screens = new GameObject[];
        screens = GameObject.FindGameObjectsWithTag("Screen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
