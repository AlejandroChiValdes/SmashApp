using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayP2Score : MonoBehaviour {

    [SerializeField] Text P2Score;

    void Awake()
    {
        P2Score.text = GameState.state.matchData.getP2Score().ToString();
    }
}
