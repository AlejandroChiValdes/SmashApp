using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayCurrentPlayer : MonoBehaviour {
    [SerializeField] Text textComponent;
    // Use this for initialization
    void Awake()
    {
        updateName(textComponent);
    }

    public static void updateName(Text textComponent) // sets the attached text label's text value to the current player's name
    {
        int maxLength = 25;
        string playerName = GameState.state.matchData.getCurrentPlayer();
        print("current player: " + playerName);
        // truncate's player name if longer than 25 characters (could potentially lower font size instead, will deal with later)
        textComponent.text = playerName.Length > maxLength ? playerName.Substring(0, 24) + "'s" : playerName + "'s";
    }


}
