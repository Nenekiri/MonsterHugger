using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHug : MonoBehaviour {


    public float timer;
    public float hugTime; //normally set to 3.0f, which is 3 seconds but declaring this variable so I can go through and set different times for other creatures

    public GameObject floatingText; 

    // Use this for initialization
    void Start ()
    {
        floatingText.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer >= hugTime)
        {
            timer = 0.0f;
            floatingText.SetActive(true); 
        }
    }

    //method to check for a collision and then allow for the hug input to be pressed
    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //check to see if the player is currently hugging the object
            if (Globals.isHugging == true)
            {
                timer += Time.deltaTime;
            }
        }
    }//end of OnCollisionStay


}//end of class
