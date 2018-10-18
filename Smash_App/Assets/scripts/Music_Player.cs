using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Player : MonoBehaviour {

    static Music_Player instance = null; // our single music_player that the class will keep track of. 
    //This music player will remain active throughout the entire game, or until we destroy it manually

    void Awake()
    {
        if (instance != null) // If there's no music player already existing
        {
            Destroy(gameObject); // Destroys the game object to which the current game object is attached
        }
        else
        {
            instance = this; // We set the instance var to the current musicplayer instance
            GameObject.DontDestroyOnLoad(gameObject); // gameObject is the literal game object that we've attached this script to, GameObject is the class of the method 'DontDestroyOnLoad'
        }
    }
    
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
