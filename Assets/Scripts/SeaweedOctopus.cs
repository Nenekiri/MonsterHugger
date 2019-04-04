using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95; 

public class SeaweedOctopus : MonoBehaviour {

    //define animation states to switch between
    public DoodleAnimationFile animationIdle;
    public DoodleAnimationFile animationAfterHug;

    public float timer;
    public DoodleAnimator animator;
    public float hugTime; //normally set to 3.0f, which is 3 seconds but declaring this variable so I can go through and set different times for other creatures

    public GameObject tentacle1;
    public GameObject tentacle2;
    public GameObject tentacle3;
    public GameObject tentacle4;
    public GameObject tentacle5;
    public GameObject tentacle6;
    public GameObject tentacle7;
    public GameObject tentacle8;




    // Use this for initialization
    void Start()
    {
        tentacle1.SetActive(false);
        tentacle2.SetActive(false);
        tentacle3.SetActive(false);
        tentacle4.SetActive(false);
        tentacle5.SetActive(false);
        tentacle6.SetActive(false);
        tentacle7.SetActive(false);
        tentacle8.SetActive(false);
    }//end of start method

    // Update is called once per frame
    void Update()
    {
        //check the timer to see if we can change the animation
        if (timer >= hugTime)
        {
            timer = 0.0f;
            animator.ChangeAnimation(animationAfterHug);
            tentacle1.SetActive(true);
            tentacle2.SetActive(true);
            tentacle3.SetActive(true);
            tentacle4.SetActive(true);
            tentacle5.SetActive(true);
            tentacle6.SetActive(true);
            tentacle7.SetActive(true);
            tentacle8.SetActive(true);
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
