using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMatchData : MonoBehaviour {

    public void resetMatchData()
    {
        GameState.state.matchData.reset();
    }
}
