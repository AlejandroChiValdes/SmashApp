using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMatchInfo: MonoBehaviour
{
    // Utility class, all methods that alter the MatchData object within our static GameData object.
    public void setMaxGames(int x)
    {
        GameState.state.setMaxGames(x);
    }

    public void setGame(int x) // Changes the current game mode of the MatchState object within the static GameState class
        /* 0 =  Melee 1 = Sm4sh */
    {
        GameState.state.matchStaticData.setCurrentGame(x);
    }

    public void setP1Name(string x)
    {
        GameState.state.matchData.setP1Name(x);
    }

    public void setP2Name(string x)
    {
        GameState.state.matchData.setP2Name(x);
    }

    public void setCurrentPlayer (int x)
    {
        GameState.state.matchData.setCurrentPlayer(x);
    }
}
