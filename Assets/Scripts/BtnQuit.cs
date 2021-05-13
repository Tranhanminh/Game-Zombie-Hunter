using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnQuit : MonoBehaviour {
	// Use this for initialization
	void Start () {
    }
	public void QuitGame()
    {
        //Application.Quit();
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetKey("escape"))
        {
			QuitGame();
        }			
		
	}
}
