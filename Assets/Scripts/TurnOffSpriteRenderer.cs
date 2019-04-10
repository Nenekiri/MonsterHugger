using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSpriteRenderer : MonoBehaviour {

    public GameObject wall; 

	// Use this for initialization
	void Start ()
    {
        wall.GetComponent<SpriteRenderer>().enabled = false; 	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
