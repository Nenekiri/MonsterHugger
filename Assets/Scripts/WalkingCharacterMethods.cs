using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declare a new class so I can access methods
public class WalkingCharacterMethods : MonoBehaviour
{

    //maybe set up a global isHugging variable

    //method to check for a collision and then allow for the hug input to be pressed
    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Huggable")
        {
            Debug.Log("colliding with huggable object!");
            if (Input.GetButton("Hugging"))
            {
                Debug.Log("Hugging variable was set to true");
                //set global variable state for hugging
                Globals.isHugging = true;
            }
            else
            {
                Debug.Log("Hugging variable was set to false");
                Globals.isHugging = false; 
            }
        }//end of collision check
    }//end  of OnCollisionEnter
}//end of WalkingCharacterMethods
