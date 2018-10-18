using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerLabel : MonoBehaviour {

    public void updatePlayerLabel()
    {
        string playerLabel = "p" + (GameState.state.matchData.getCurrentPlayerIndex() + 1).ToString() +"_label";
        // Sets player label to whatever name the user just set their name to in the 'Set Name' Panel.
        GameObject.Find(playerLabel).GetComponent<Text>().text = GameState.state.matchData.getCurrentPlayer();
    }
}
