﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    public AudioSource audio;
    public AudioClip cameraClick; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Screenshot"))
        {
            string date = System.DateTime.Now.ToString();
            date = date.Replace("/", "-");
            date = date.Replace(" ", "_");
            date = date.Replace(":", "-");
            ScreenCapture.CaptureScreenshot("SS_" + date + ".png"); 
            //This line works in editor, but not in build
            //ScreenCapture.CaptureScreenshot(Application.dataPath + "/ScreenShots/SS_" + date + ".png");
            audio.PlayOneShot(cameraClick);
        }
		
	}

}//end of class
