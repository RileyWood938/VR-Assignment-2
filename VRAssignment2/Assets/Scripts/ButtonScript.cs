using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Material normal;
    public Material changedColor;
    public bool changed = false;
    [Range(0, 360)]
    public float maximumAngleForEvent = 15f;
    public GameControl gameControl;
    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("PlayerCamera").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        var cameraForward = Camera.main.transform.forward;
        var vectorToObject = transform.position - Camera.main.transform.position;

        // Check if the angle between the camera and object is within the hover range
        var angleFromCameraToObject = Vector3.Angle(cameraForward, vectorToObject);
        if (angleFromCameraToObject <= maximumAngleForEvent)
        {


            if (XRInputManager.IsButtonDown())
            {
                ButtonPressed();
            }
        }
    }
    public void ButtonPressed()
    {
        if (changed)
        {
            gameControl.checkButton(gameObject);
        }
        
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
    public Material fetchColor()
    {
        return changedColor;
    }
}
