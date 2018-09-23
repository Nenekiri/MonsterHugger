using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //Methods for the MainMenu

    //For use in loading the levels
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //For linking to URL's outside of the project
    public void NavigateURL(string URL)
    {
        Application.OpenURL(URL);
    }

    //For quitting the application
    public void GTFO()
    {
        Application.Quit();
    }

}//end of Main Menu class
