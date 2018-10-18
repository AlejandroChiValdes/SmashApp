using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentPlayer : MonoBehaviour {

    public void setCurrentPlayer(int x)
    {
        GameState.state.matchData.setCurrentPlayer(x);
    }

    public void setCurrentPlayerName(string x)
    {
        GameState.state.matchData.setCurrentPlayerName(x);
    }
}
