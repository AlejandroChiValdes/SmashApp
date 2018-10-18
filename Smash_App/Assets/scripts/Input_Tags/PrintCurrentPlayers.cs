using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCurrentPlayers : MonoBehaviour {


    public void printPlayers()
    {
        print("Player 1 Char: " + GameState.state.matchData.getPlayerName(0));
        print("Player 2 Char: " + GameState.state.matchData.getPlayerName(1));
    }
}
