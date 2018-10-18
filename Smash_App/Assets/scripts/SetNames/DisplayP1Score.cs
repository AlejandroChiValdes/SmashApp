using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayP1Score : MonoBehaviour {
    [SerializeField] Text PlayerScore;

	void Awake()
    {
        PlayerScore.text = GameState.state.matchData.getP1Score().ToString();
    }
}
