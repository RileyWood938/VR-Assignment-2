using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Material normal;
    public Material changedColor;
    public bool changed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchColorToNormal()
    {
        GetComponent<Renderer>().material = normal;
        changed = false;
    }
    public bool isChanged()
    {
        return changed;
    }
    public void changeColor(Material m)
    {
        changedColor = m;
        GetComponent<Renderer>().material = changedColor;
        changed = true;

    }
}
