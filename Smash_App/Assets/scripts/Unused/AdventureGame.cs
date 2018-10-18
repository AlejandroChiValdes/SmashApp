using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent; //Variable is now available in the inspector
    [SerializeField] State startingState;
    //[SerializeField] State Room1;
    //[SerializeField] State Room2;
    

    State state; // keeps track of what state we're currently in

	// Use this for initialization
	void Start () {
        state = startingState;
        UpdateText(); // our 'story text' value changes depending on which state we're in

    }

    
	
	// Update is called once per frame
	void Update () {
        ManageState();
        CheckFinished();
        UpdateText();
        
	}

    private void CheckFinished()
    {
        if (textComponent.text == "U Cucked Nigga")
            SceneManager.LoadScene("Lose");
    }

    private void UpdateText()
    {
        textComponent.text = state.GetStateStory();
    }

    private void ManageState()
    {
        State[] nextStates = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Application.Quit();
        }
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    state = nextStates[2];
        //}
    }
}
