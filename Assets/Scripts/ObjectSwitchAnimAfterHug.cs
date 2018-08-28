using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class ObjectSwitchAnimAfterHug : MonoBehaviour {


    //define animation states to switch between
    public DoodleAnimationFile animationIdle;
    public DoodleAnimationFile animationAfterHug;

    public float timer;
    public DoodleAnimator animator;
    public float hugTime; //normally set to 3.0f, which is 3 seconds but declaring this variable so I can go through and set different times for other creatures

    // Use this for initialization
    void Start ()
    {
		
	}//end of start method
	
	// Update is called once per frame
	void Update ()
    {
        //check the timer to see if we can change the animation
        if (timer >= hugTime)
        {
            timer = 0.0f;
            animator.ChangeAnimation(animationAfterHug);
        }
		
	}//end of update

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
