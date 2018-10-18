using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCharsChosen : MonoBehaviour {

    public void toRPS()
    {
        //Checks if both characters have been chosen. If so, switch to RPS screen
        // If not, stay on this screen.
        if (checkBothCharsChosen())
        {
            SceneManager.LoadScene("RPS");
        }
    }

    static bool checkBothCharsChosen()
    {
        return GameState.state.matchData.getPlayerChar(0) != "" && GameState.state.matchData.getPlayerChar(1) != "";
    }
}
