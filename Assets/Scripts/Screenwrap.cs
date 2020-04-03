using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attaching this script to any object and equipping a camera (which serves as the "border") will cause the object to effectively screenwrap.

public class Screenwrap : MonoBehaviour
{
    public Camera screencam;
    public bool active;

    void Start()
    {
        screencam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //confirm that we actually want active screenwrapping:
        if (active)
        {
            //first just keep track of where the ship is in terms of pixels on camera
            var screenpos = screencam.WorldToScreenPoint(transform.position);

            //also make some helper variables for the bottom left and upper right corners (+1 pixel padding to avoid weird tearing)
            var ur = new Vector3(screencam.pixelWidth - 1, screencam.pixelHeight - 1, 0);
            var bl = new Vector3(1, 1, 0);

            //then compare it with the camera's width and height values to figure out if it's offscreen:
            if (screenpos.x > screencam.pixelWidth)
            {
                transform.position = new Vector3(screencam.ScreenToWorldPoint(bl).x, transform.position.y, 0);
            }
            if (screenpos.x < 0)
            {
                transform.position = new Vector3(screencam.ScreenToWorldPoint(ur).x, transform.position.y, 0);
            }
            if (screenpos.y > screencam.pixelHeight)
            {
                transform.position = new Vector3(transform.position.x, screencam.ScreenToWorldPoint(bl).y, 0);
            }
            if (screenpos.y < 0)
            {
                transform.position = new Vector3(transform.position.x, screencam.ScreenToWorldPoint(ur).y, 0);
            }
        }
    }
}